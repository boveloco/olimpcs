using Syrinj;

class SingletonHub
{
    public static SingletonHub instance = null;

    public static SingletonHub getInstance()
    {
        if (instance == null)
        {
            instance = new SingletonHub();
        }
        return instance;
    }
    public SingletonHub()
    {
        pausedState = PausedState.getInstance();
        playinState = PlayingState.getInstance();
        weaponState = WeaponState.getInstance();
        manager = Manager.getInstance();
    }

    public PausedState pausedState;

    public PlayingState playinState;

    public WeaponState weaponState;

    [Provides]
    [Singleton]
    public Manager manager;

}