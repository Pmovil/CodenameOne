
public class Main implements Runnable {

    public static ##packageName##.##mainName## i;

    public static void main(String agrs[]){
        new Main();
    }
    
    public Main() {
        com.codename1.ui.Display.getInstance().callSerially(this);
    }

    public void run() {
        i = new ##packageName##.##mainName##();
        i.init(this);
    }

    public void start() {
        com.codename1.ui.Display.getInstance().callSerially(new StartClass());
    }

    public void stop() {
        com.codename1.ui.Display.getInstance().callSerially(new StopClass());
    }

    class StartClass implements Runnable {

        public void run() {
            Main.i.start();
        }
    }

    class StopClass implements Runnable {

        public void run() {
            Main.i.stop();
        }
    }
}
