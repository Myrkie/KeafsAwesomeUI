using System;

namespace KeafsAwesomeUI
{
    public class ToastContent
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ToastContent CopyWithNewContent(string Content)
        {
            ToastContent newToastContent = (ToastContent) this.MemberwiseClone();
            newToastContent.Content = Content;
            return newToastContent;
        }
        
    }
}