using CsCourse.ValueReference.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CsCourse.ValueReference.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCopyValueType_Click(object sender, RoutedEventArgs e)
        {
            int i = 42;
            int j = i;
            i++;
            Debug.Print("i = {0}, j = {1}", i, j);
        }

        private void btnCopyValueTypeEnum_Click(object sender, RoutedEventArgs e)
        {
            CarType type1 = CarType.Crossover;
            CarType type2 = type1;
            type1 = CarType.HatchBack;
            Debug.Print("Type1 = {0}, Type2 = {1}", type1, type2);
        }

        private void btnCopyValueTypeStruct_Click(object sender, RoutedEventArgs e)
        {
            Vector3d vector1 = new Vector3d(2, 3, 4);
            Vector3d vector2 = vector1;
            vector1.X++;
            vector1.Y++;
            vector1.Z++;
            Debug.Print("Vector1: X = {0}, Y = {1}, Z = {2}", vector1.X, vector1.Y, vector1.Z);
            Debug.Print("Vector2: X = {0}, Y = {1}, Z = {2}", vector2.X, vector2.Y, vector2.Z);
        }

        private void btnCopyReferenceType_Click(object sender, RoutedEventArgs e)
        {
            Car car1 = new Car("Honda", CarType.HatchBack, 100M);
            Car car2 = car1;
            car1.Speed += 10;
            Debug.Print("car 1 speed = {0}, car 2 speed = {1}", car1.Speed, car2.Speed);
        }

        private void btnCopyReferenceTypeString_Click(object sender, RoutedEventArgs e)
        {
            string string1 = "Hello";
            string string2 = string1;
            string1 = string1.ToUpper(); //string1 krijgt een nieuwe waarde
            Debug.Print("string1 = {0}, string2 = {1}", string1, string2);
        }

        private void IncrementNumber(int number)
        {
            number++;
        }

        private void btnPassValueType_Click(object sender, RoutedEventArgs e)
        {
            int numberToInput = 5;
            IncrementNumber(numberToInput);
            Debug.Print("numberToInput has value: {0}", numberToInput);
        }

        private void IncrementNumberRef(ref int number)
        {
            number++;
        }

        private void btnPassValueTypeByRef_Click(object sender, RoutedEventArgs e)
        {
            int numberToInput = 5;
            IncrementNumberRef(ref numberToInput);
            Debug.Print("numberToInput has value: {0}", numberToInput);
        }

        private bool InitializeMe(out int numberToInitialize)
        {
            //the value of numberToInitialize is always discarded when passing as out
            numberToInitialize = 42;
            return true;
        }

        private void btnOutputParameter_Click(object sender, RoutedEventArgs e)
        {
            int numberComingOut = 66;
            bool ok = InitializeMe(out numberComingOut);
            Debug.Print("numberComingOut has value: {0}", numberComingOut);
        }

        //because the type of whateverObject is object, ANYTHING can be passed in!
        private void PrintObjectAsString(object whateverObject)
        {
            //print the actual TYPE of the object passed in followed by the value of the ToString() method
            Debug.Print("Object is a {0}, ToString: {1}", 
                whateverObject.GetType().ToString(), 
                whateverObject.ToString());
        }


        private void btnBoxing_Click(object sender, RoutedEventArgs e)
        {
            int number = 42;
            object boxedNumber = number; //boxing happens implicitly

            number++; //this variable is still on the stack

            Car myCar = new Car("Ford", CarType.Sedan, 90);
            object abstractCar = myCar;  //no boxing, myCar is already on the heap

            PrintObjectAsString(boxedNumber);
            PrintObjectAsString(number);
            PrintObjectAsString(abstractCar);
        }

        private void btnUnboxing_Click(object sender, RoutedEventArgs e)
        {
            int number = 42;
            object boxedNumber = number; //boxing

            int unboxed = (int)boxedNumber; //unboxing to correct type
        }

        private void btnSafeCasting_Click(object sender, RoutedEventArgs e)
        {
            int? myNumber = 42;
            object boxedNumber = myNumber;
            int? myNumberAgain = boxedNumber as int?; //safe typecast

            if (myNumberAgain != null)
                Debug.Print("myNumberAgain: {0}", myNumberAgain.ToString());
            else
                Debug.Print("myNumberAgain was casted to wrong type");

            Car myCar = new Car("Toyota", CarType.SUV, 65);
            object boxedCar = myCar;
            Window myCarAgain = boxedCar as Window; //safe cast fails due to type mismatch, myCarAgain is null!

            if (myCarAgain != null)
                Debug.Print("myCarAgain: {0}", myCarAgain.ToString());
            else
                Debug.Print("myCarAgain was casted to wrong type");
        }
    }
}
