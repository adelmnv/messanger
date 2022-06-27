using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Study
{
    class Presenter
    {
        private Abstractions.IModel model;
        private Abstractions.IView view;


        public Presenter(Abstractions.IModel model, Abstractions.IView view)
        {
            this.model = model;
            this.view = view;

            //this.view.OnTextChanged += Show;
            //this.view.SaveValue+= Save;
            //this.view.GetResult += Result;
        }
        //void Save(object sender, EventArgs e)
        //{
        //    model.SaveIn(view.TextBox);
        //}
        //void Result(object sender, EventArgs e)
        //{
            
        //    view.ClearText();
        //    view.GetRes(model.Operation());
        //}
        //void Show(object sender, EventArgs e)
        //{
        //    model.ShowIn(view.TextBox);
        //}
    }
}
