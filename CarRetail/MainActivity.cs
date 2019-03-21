using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
namespace CarRetail
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       
        Spinner carNames;
        TextView carPriceTv;
        ImageView carImages;


        double[] carPriceArray = { 120000, 90000, 70000, 67000, 55000, 73000 };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            carNames = (Spinner)FindViewById(Resource.Id.fidgetSpinner);
            carPriceTv = (TextView)FindViewById(Resource.Id.priceOutputTv);
            carImages = (ImageView)FindViewById(Resource.Id.carImageView);

            var carNamesAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.CarArray, Android.Resource.Layout.SimpleSpinnerItem);
            carNames.Adapter = carNamesAdapter;

            carNames.ItemSelected += delegate
            {
                long i = carNames.SelectedItemId;
                carPriceTv.Text = carPriceArray[i].ToString();
                Toast.MakeText(this, "The Selected Car is : " + carNames.SelectedItem, ToastLength.Long).Show();
                string imgName = "car" + i;
                int imgId = this.Resources.

            };
        }


            
    

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

