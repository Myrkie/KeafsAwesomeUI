# KeafsAwesomeUI


More Features to come soon


# How to use
 1. Reference KeafsAwesomeUI.dll
 2. In your mod have a field called
 ```cs
    private static ToastContent tc;
 ```
 4. In start have
 ```cs
 tc = new ToastContent { Title = "EPik MOD" };
 ```
 5. when you want to add to toast call this
 ```cs
 KeafUI.toastcontent.Add(tc.CopyWithNewContent("Hi"));
 ```
