using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ##mainName##
{
    class Main : java.lang.Object, java.lang.Runnable
    {
        public static global::##packageName##.##mainName## i;
        public Main() 
        {
            @this();
            ((com.codename1.ui.Display)com.codename1.ui.Display.getInstance()).callSerially(this);
            if (i is com.codename1.payment.PurchaseCallback)
            {
                com.codename1.impl.SilverlightImplementation.setPurchaseCallback(i);
            }
        }
        public void run()
        {
            i = new global::##packageName##.##mainName##();
            i.@this();
            i.init(this);
        }
        public void start()
        {
            ((com.codename1.ui.Display)com.codename1.ui.Display.getInstance()).callSerially(new StartClass());
        }
        public void stop()
        {
            ((com.codename1.ui.Display)com.codename1.ui.Display.getInstance()).callSerially(new StopClass());
        }
    }
    class StartClass : java.lang.Object, java.lang.Runnable
    {
        public void run()
        {
            Main.i.start();
        }
    }
    class StopClass : java.lang.Object, java.lang.Runnable
    {
        public void run()
        {
            Main.i.stop();
        }
    }
}