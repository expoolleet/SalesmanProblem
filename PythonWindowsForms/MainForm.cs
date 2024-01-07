using System;
using System.Linq;
using System.Windows.Forms;
using Python.Runtime;
using PythonWindowsForms;

namespace SalesmanProblem
{
    public partial class MainForm : Form
    {
        private int[,] _matrix;

        private string _salesmanScript = "salesman";

        public MainForm()
        {
            Runtime.PythonDLL = @"..\python311.dll";
            PythonEngine.Initialize();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = textBoxMatrix.Lines;

            char[] splitChar = { ',', ' '};

            if (lines.Length == 0)
                return;

            var n = lines[0].Split(splitChar).Length;

            if (n == 1 || n != lines.Length) 
                return;

            _matrix = new int[n, n];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(splitChar);

                for (int j = 0; j < line.Length; j++)
                {
                    _matrix[i, j] = int.Parse(line[j]);
                }
            }
            RunScript(_salesmanScript, _matrix);
        }
        public void RunScript(string scriptName, int[,] matrix)
        {
            using (Py.GIL())
            {
                var ob = new PyList();

                dynamic np = Py.Import("numpy");

                var pythonArray = np.array(matrix);

                var pythonScript = Py.Import(scriptName);

                var pyobject = pythonScript.InvokeMethod("Main", new PyObject[] {pythonArray});

                var output = pyobject.As<PyTuple>();

                var pathList = output[0].As<PyList>();
                var length = output[1].As<int>();
                var stepsOutput = output[2].As<string>();                

                textBoxPath.Text = "{";
                for (int i = 0; i < pathList.Count() - 1; i++)
                {
                    var vertex1 = pathList[i].As<int>();
                    i++;
                    var vertex2 = pathList[i].As<int>();
                    textBoxPath.Text += (i != pathList.Count() - 1) ? $"({vertex1}; {vertex2}), " : $"({vertex1}; {vertex2})";
                }
                textBoxPath.Text += "}";

                textBoxStepsOutput.Text = stepsOutput;

                textBoxPathLength.Text = length.ToString();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formHelp = new FormHelp();
            formHelp.ShowDialog();
        }
    }
}
