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
        EditText carModelEt, carPriceEt;
        RadioButton cashRdBtn, financeRdBtn;
        Button btnTotal;
        TextView tvTotalOutput;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            carModelEt = (EditText)FindViewById(Resource.Id.carEt);
            carPriceEt = (EditText)FindViewById(Resource.Id.priceEt);
            cashRdBtn = (RadioButton)FindViewById(Resource.Id.cashRadioGrp);
            financeRdBtn = (RadioButton)FindViewById(Resource.Id.financeRadioGrp);
            btnTotal = (Button)FindViewById(Resource.Id.totalBtn);
            tvTotalOutput = (TextView)FindViewById(Resource.Id.totalTv);


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

