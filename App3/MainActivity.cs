using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;

namespace App3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText eta;
        EditText etb;
        EditText etc;

        TextView resultado;

        Button button;
        View v;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            eta = FindViewById<EditText>(Resource.Id.editTextA);
            etb = FindViewById<EditText>(Resource.Id.editTextB);
            etc = FindViewById<EditText>(Resource.Id.editTextC);

            resultado = FindViewById<TextView>(Resource.Id.textViewResultado);
            button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate
            {
                Calcular(v);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Calcular(View v)
        {
            float a, b, c, delta;

            a = float.Parse(eta.Text);
            b = float.Parse(etb.Text);
            c = float.Parse(etc.Text);

            delta = (b * b) - (4 * a * c);

            if (delta < 0)
            {
                resultado.Text = "Equacao nao possui raizes reais";
            }
            else
            {
                double x1, x2;
                x1 = ((b * -1) + Math.Sqrt(delta)) / (2 * a);
                x2 = ((b * -1) - Math.Sqrt(delta)) / (2 * a);

                x1 = Math.Round(x1, 2);
                x2 = Math.Round(x2, 2);

                resultado.Text = $"X' = {x1} X\'' = {x2} ";
            }
        }
    }
}