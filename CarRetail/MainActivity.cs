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
        string[] carNames = { "Mercedes", "BMW", "Toyota", "Honda", "Nissan", "Ford" };
        double[] carPrice = { 120000, 90000, 70000, 67000, 55000, 73000 };

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

            carModelEt.TextChanged += delegate {
                int s = search();
                if (s == -1)
                {
                    Toast.MakeText(this, "The car doesn't exist", ToastLength.Long).Show();
                    carPriceEt.Text = "";
                }
                else
                    carPriceEt.Text = carPrice[s].ToString();
            };
            btnTotal.Click += delegate {
                double price = double.Parse(carPriceEt.Text);
                if (cashRdBtn.Checked)
                    price = price * 1.13;
                else if (financeRdBtn.Checked)
                    price = price * 1.23;
                tvTotalOutput.Text = price.ToString();

            };

        }
        //function to search for an item in the array and returns its index or -1 if not exist
        int search()
        {
            if (carModelEt.Text != "")
            {
                string name = carModelEt.Text;
                for (int i = 0; i < carNames.Length; i++)
                    if (name.ToLower() == carNames[i].ToLower())
                        return i;
                return -1;
            }
            else
            {
                Toast.MakeText(this, "Pleasae enter a car name", ToastLength.Long).Show();
                carPriceEt.Text = "";
                return -1;
            }

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

