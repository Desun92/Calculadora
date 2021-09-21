using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculadora
{
    public partial class Calculadora : Form
    {
        double numA; //Variable en la que guardaremos el primer número
        double numB; //Variable en la que guardaremos el segundo número
        double memoria; //Variable destinada a la memoria (para guardarnos un número)
        int contOperacion=0; //Variable que controla si estamos en medio de una operación o no para borrar la pantalla y que no se acumulen números que no queremos
        bool coma = false; //Variable que controla que solo podamos meter la coma una vez por número
        bool suma = false; //Variable que controla si venimos de una suma anterior para ir haciéndolas de manera contínua, sin necesidad de darle al "="
        bool resta = false; //Variable que controla si venimos de una resta anterior para ir haciéndolas de manera contínua, sin necesidad de darle al "="
        bool multiplicacion = false; //Variable que controla si venimos de una multiplicación anterior para ir haciéndolas de manera contínua, sin necesidad de darle al "="
        bool division = false; //Variable que controla si venimos de una división anterior para ir haciéndolas de manera contínua, sin necesidad de darle al "="
        bool operacion = false; //Variable que controla si estamos en mitad de una operación, para que no podamos darle repetidas veces al "+" o "-" o "*" o "/"
        bool igual = false; //Variable que controla que le demos una sola vez al igual ("=") por cada operación

        public Calculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCero_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            /*Si venimos de una operación anterior y el contador de operación está en cero, se borrará el texto que haya en la calculadora para dejar espacio al nuevo número y se incrementará en 1 el contador, para así cuando terminemos una operación, este vuelva a ser de cero
            y no se nos acumule el resultado de la operación anterior con el nuevo número introducido.*/

            if (suma || resta || multiplicacion || division || igual) 
                if(contOperacion == 0)
                    {
                        TxtCalculadora.Text = "";
                        contOperacion = 1;
                    }

            //En función del número introducido lo añadimos a la pantalla. Véase que si el número es un cero, solo se permitirá introducir uno, a no ser que vaya precedido de una coma, en cuyo caso se nos permitirá introducir cuantos ceros queramos.

            string CopiaCalculadora = TxtCalculadora.Text;

            switch (boton.Name)
            {
                case "BtnCero":
                    bool CeroYaColocado = false;
                    if(!CopiaCalculadora.StartsWith("0"))
                    {
                        TxtCalculadora.Text += "0";
                        operacion = false;
                        CeroYaColocado = true;
                    }
                    if(CopiaCalculadora.Length>1 && CopiaCalculadora.IndexOf(",")==1 && !CeroYaColocado)
                    {
                        TxtCalculadora.Text += "0";
                        operacion = false;
                    }                                                
                    break;
                case "BtnUno":
                    TxtCalculadora.Text += "1";
                    operacion = false;
                    break;
                case "BtnDos":
                    TxtCalculadora.Text += "2";
                    operacion = false;
                    break;
                case "BtnTres":
                    TxtCalculadora.Text += "3";
                    operacion = false;
                    break;
                case "BtnCuatro":
                    TxtCalculadora.Text += "4";
                    operacion = false;
                    break;
                case "BtnCinco":
                    TxtCalculadora.Text += "5";
                    operacion = false;
                    break;
                case "BtnSeis":
                    TxtCalculadora.Text += "6";
                    operacion = false;
                    break;
                case "BtnSiete":
                    TxtCalculadora.Text += "7";
                    operacion = false;
                    break;
                case "BtnOcho":
                    TxtCalculadora.Text += "8";
                    operacion = false;
                    break;
                case "BtnNueve":
                    TxtCalculadora.Text += "9";
                    operacion = false;
                    break;
                case "BtnComa":                                         //Si introducimos una coma, el booleano se activa, de modo que no nos deje introducir otra hasta que finalice la operación en curso, para así no poder tener números tipo: 2.32.45.4...
                    if(!coma && CopiaCalculadora.Length > 0)            //y de igual modo se comprueba que la coma no toma el primer lugar, para asi no tener un "número" que empiece por una coma
                    {
                        TxtCalculadora.Text += ",";
                        coma = true;
                    }
                    break;
            }
        }

        /*Los métodos que controlan las operaciones básicas funcionan todos igual, primero controlan si venimos de una operación anterior, para que en el caso de que así sea, no se pueda dar reiteradas veces a cualquier botón que realice una operación. Lo controlamos con el booleano "operacion".
        En segundo lugar, se comprueba si hay alguna operacion en curso, para que si es así, se puedan realizar operaciones sin necesidad de darle al "=" y que se nos muestre el resultado de forma continuada.
        Por último, se toman los valores que haya en la pantalla y se asignan a nuestras dos variables numéricas para realizar las operaciones requeridas.*/

        private void BtnSumar_Click(object sender, EventArgs e)
        {
            if (!operacion)
            {
                if (division && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA / numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = true;
                    resta = false;
                    multiplicacion = false;
                    division = false;
                }
                else if (multiplicacion && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA * numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = true;
                    resta = false;
                    multiplicacion = false;
                    division = false;
                }
                else if (resta && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA - numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = true;
                    resta = false;
                    multiplicacion = false;
                    division = false;
                }
                else if (!suma && !TxtCalculadora.Text.Equals(""))
                {
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = "";
                    suma = true;
                }
                else if (suma)
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA + numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                }
                igual = false;
                coma = false;
                operacion = true;
            }
            
        }

        private void BtnRestar_Click(object sender, EventArgs e)
        {
            if (!operacion)
            {
                if (division && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA / numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = true;
                    multiplicacion = false;
                    division = false;
                }
                else if (multiplicacion && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA * numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = true;
                    multiplicacion = false;
                    division = false;
                }
                else if (suma && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA + numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = true;
                    multiplicacion = false;
                    division = false;
                }
                else if (!resta && !TxtCalculadora.Text.Equals(""))
                {
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = "";
                    resta = true;
                }
                else if (resta)
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA - numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                }
                igual = false;
                coma = false;
                operacion = true;
            }
            
        }

        private void BtnMultiplicar_Click(object sender, EventArgs e)
        {
            if (!operacion)
            {
                if (division && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA / numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = false;
                    multiplicacion = true;
                    division = false;
                }
                else if (resta && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA - numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = false;
                    multiplicacion = true;
                    division = false;
                }
                else if (suma && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA + numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = false;
                    multiplicacion = true;
                    division = false;
                }
                else if (!multiplicacion && !TxtCalculadora.Text.Equals(""))
                {
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = "";
                    multiplicacion = true;
                }
                else if (multiplicacion)
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA * numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                }
                igual = false;
                coma = false;
                operacion = true;
            }
            
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            if (!operacion)
            {
                if (multiplicacion && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA * numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = false;
                    multiplicacion = false;
                    division = true;
                }

                else if (resta && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA - numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = false;
                    multiplicacion = false;
                    division = true;
                }
                else if (suma && !TxtCalculadora.Text.Equals(""))
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA + numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                    suma = false;
                    resta = false;
                    multiplicacion = false;
                    division = true;
                }
                else if (!division && !TxtCalculadora.Text.Equals(""))
                {
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = "";
                    division = true;
                }
                else if (division)
                {
                    numB = Convert.ToDouble(TxtCalculadora.Text);
                    TxtCalculadora.Text = Convert.ToString(numA / numB);
                    numA = Convert.ToDouble(TxtCalculadora.Text);
                    contOperacion = 0;
                }
                igual = false;
                coma = false;
                operacion = true;
            }
            
        }

        /*Este botón realiza la operación que se esté ejecutando, comprobando de qué operación previa venimos. Una vez se realiza la acción, los booleanos que realizan la comprobación de las operaciones de las que partimos se reinicializan y se activa el booleano "igual"
        para asegurarnos que no se pueda pulsar dos veces seguidas el mismo botón, así como el de la coma*/

        private void BtnIgual_Click(object sender, EventArgs e)
        {

            if (!igual && !TxtCalculadora.Text.Equals(""))
            {
                numB = Convert.ToDouble(TxtCalculadora.Text);

                if (suma)
                {
                    TxtCalculadora.Text = Convert.ToString(numA + numB);
                }
                else if (resta)
                {
                    TxtCalculadora.Text = Convert.ToString(numA - numB);
                }
                else if (multiplicacion)
                {
                    TxtCalculadora.Text = Convert.ToString(numA * numB);
                }
                else
                {
                    TxtCalculadora.Text = Convert.ToString(numA / numB);
                }

                suma = false;
                resta = false;
                multiplicacion = false;
                division = false;
                igual = true;
                coma = false;
                contOperacion = 0;
            }
            
        }

        //Botón que reinicializa la calculadora

        private void BtnC_Click(object sender, EventArgs e)
        {
            numA = 0;
            numB = 0;
            TxtCalculadora.Text = "";
            suma = false;
            resta = false;
            multiplicacion = false;
            division = false;
            coma = false;
        }

        //Botón que reinicializa el último número introducido

        private void BtnCe_Click(object sender, EventArgs e)
        {
            /*String pantalla = TxtCalculadora.Text;
            pantalla=pantalla.Remove(pantalla.Length - 1);
            TxtCalculadora.Text = pantalla;
            */

            numB = 0;
            TxtCalculadora.Text = "";
        }

        //Botón que guarda en la memoria el número actual en pantalla

        private void BtnMs_Click(object sender, EventArgs e)
        {
            memoria = Convert.ToDouble(TxtCalculadora.Text);
        }

        //Trae a la pantalla el número almacenado en memoria

        private void BtnMr_Click(object sender, EventArgs e)
        {
            TxtCalculadora.Text = Convert.ToString(memoria);
        }

        //Botón que reinicializa la memoria a cero

        private void BtnMC_Click(object sender, EventArgs e)
        {
            memoria = 0;
        }

        //Botón que incrementa el valor de la memoria sumando el actual número en pantalla

        private void BtnMMas_Click(object sender, EventArgs e)
        {
            memoria += Convert.ToDouble(TxtCalculadora.Text);
        }

        //Botón que divide 1 entre el número actual en pantalla

        private void BtnUnoX_Click(object sender, EventArgs e)
        {
            double pantalla = Convert.ToDouble(TxtCalculadora.Text);
            pantalla = 1 / pantalla;
            TxtCalculadora.Text = Convert.ToString(pantalla);
        }
    }
}
