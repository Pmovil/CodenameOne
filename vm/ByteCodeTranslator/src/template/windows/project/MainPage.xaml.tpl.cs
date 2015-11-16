using com.codename1.ui;
using ##mainName##;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Facebook.Client;
using Facebook;
using Facebook.Client.Controls;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ##mainName##
{

    public sealed partial class MainPage : Page
    {
        public static String BUILD_KEY = "##keyUUID##";
        public static String PACKAGE_NAME = "##packageName##";
        public static String BUILT_BY_USER = "##cn1User##";
        public static String APP_NAME = "##mainName##";
        public static String APP_VERSION = "##appVersion##";
        private Main instance;
        public MainPage()
        {

            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            Loaded += delegate
            {
                if (instance == null)
                {
                    com.codename1.impl.SilverlightImplementation.setCanvas(this, LayoutRoot);
                    com.codename1.ui.Display.init(null);
                    com.codename1.ui.Display disp = (com.codename1.ui.Display)com.codename1.ui.Display.getInstance();
                    disp.setProperty(global::com.codename1.impl.SilverlightImplementation.toJava("package_name"), global::com.codename1.impl.SilverlightImplementation.toJava(PACKAGE_NAME));
                    disp.setProperty(global::com.codename1.impl.SilverlightImplementation.toJava("built_by_user"), global::com.codename1.impl.SilverlightImplementation.toJava(BUILT_BY_USER));
                    disp.setProperty(global::com.codename1.impl.SilverlightImplementation.toJava("build_key"), global::com.codename1.impl.SilverlightImplementation.toJava(BUILD_KEY));
                    disp.setProperty(global::com.codename1.impl.SilverlightImplementation.toJava("AppName"), global::com.codename1.impl.SilverlightImplementation.toJava(APP_NAME));
                    disp.setProperty(global::com.codename1.impl.SilverlightImplementation.toJava("AppVersion"), global::com.codename1.impl.SilverlightImplementation.toJava(APP_VERSION));
                    instance = new Main();
                    Window.Current.Activated += Current_Activated;
                    // Window.Current.VisibilityChanged += Current_VisibilityChanged;
                    // Window.Current.SizeChanged += Current_SizeChanged;


                    bool firstTime = com.codename1.io.Preferences.get(global::com.codename1.impl.SilverlightImplementation.toJava("cn1_first_time_req"), true);
                    if (firstTime)
                    {
                        com.codename1.io.Preferences.set(global::com.codename1.impl.SilverlightImplementation.toJava("cn1_first_time_req"), false);
                        Request r = new Request();
                        r.setPost(false);
                        r.setFailSilently(true);
                        r.setUrl(global::com.codename1.impl.SilverlightImplementation.toJava("https://codename-one.appspot.com/registerDeviceServlet"));
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("a"),
                            global::com.codename1.impl.SilverlightImplementation.toJava("##mainName##"));
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("b"),
                            global::com.codename1.impl.SilverlightImplementation.toJava(BUILD_KEY));
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("by"),
                            global::com.codename1.impl.SilverlightImplementation.toJava(BUILT_BY_USER));
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("p"),
                            global::com.codename1.impl.SilverlightImplementation.toJava(PACKAGE_NAME));
                        java.lang.String ver = (java.lang.String)disp.getProperty(
                            com.codename1.impl.SilverlightImplementation.toJava("AppVersion"),
                            com.codename1.impl.SilverlightImplementation.toJava(APP_VERSION));
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("v"), ver);
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("pl"), (java.lang.String)disp.getPlatformName());
                        r.addArgument(global::com.codename1.impl.SilverlightImplementation.toJava("u"), global::com.codename1.impl.SilverlightImplementation.toJava(""));
                        com.codename1.io.NetworkManager n = (com.codename1.io.NetworkManager)com.codename1.io.NetworkManager.getInstance();
                        n.addToQueue(r);
                    }
                }
            };
            FacebookUriMapper();
        }
        void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {

            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                instance.stop();
            }
            else if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.PointerActivated)
            {
                if (!com.codename1.impl.SilverlightImplementation.exitLock)
                {
                    instance.start();
                }
            }
            else if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.CodeActivated)
            {
                if (!com.codename1.impl.SilverlightImplementation.exitLock)
                {
                    instance.start();
                }
            }

        }
        private void FacebookUriMapper()
        {
           Session.ActiveSession.LoginWithBehavior("email,public_profile,user_friends", FacebookLoginBehavior.LoginBehaviorAppwithMobileInternetFallback);      
        }
       
    }

    public class Request : com.codename1.io.ConnectionRequest
    {
        public Request()
        {
            @this();
        }

        public override void readResponse(global::java.io.InputStream n1)
        {
            java.io.DataInputStream di = new java.io.DataInputStream();
            di.@this(n1);
            long l = di.readLong();
            com.codename1.io.Preferences.set(global::com.codename1.impl.SilverlightImplementation.toJava("DeviceId__$"), l);
        }

    }
         
}
