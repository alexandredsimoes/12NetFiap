﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Lista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClasseView : ContentPage
	{
		public ClasseView ()
		{
			InitializeComponent ();

            lstCursos.ItemsSource = Curso.GetListaDeCursos();

        }
	}
}