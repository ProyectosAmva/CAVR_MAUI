namespace MauiCAVR.ViewModels;

public class MainViewModel : BaseViewModel
{


    public MainViewModel()
    {
        instance = this;
        //instance.OperativosViewModel = new OperativosViewModel();

    }

    #region Singleton
    private static MainViewModel? instance;
    public static MainViewModel GetInstance()
    {
        if (instance == null)
        {
            return new MainViewModel();
        }
        return instance;
    }

    #endregion
}
