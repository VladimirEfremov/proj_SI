using System;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Threading;
using System.Reflection;

namespace ServiceMoq
{

    public class Util
    {
        //Solution.Namespace.Class
        private static int SOLUTION_INDEX_IN_PATH = 0;
        private static int NAMESPACE_INDEX_IN_PATH = 1;
        private static int CLASS_INDEX_IN_PATH = 2;
        private static int COMPONENTS_IN_PATH = 3;

        //settings
        public static bool CreateUI = false;
        public static bool RunUI = false;

        public static StringBuilder s_CoreXamlSb;
        public static StringBuilder s_CoreXamlCsSb;
        public static StringBuilder s_CoreViewModelSb;

        public static StringBuilder s_NamespaceViewXamlSb = new StringBuilder();
        public static StringBuilder s_NamespaceViewXamlCsSb = new StringBuilder();

        public static string s_TAB4;
        public static string s_TAB8;
        public static string s_TAB12;
        public static string s_TAB16;
        public static string s_TAB20;
        public static string[] s_ExceptionsArray;
        public static Dictionary<string, string> s_ToShortType;
        public static string s_CurrentExeDirectory;
        public static List<string> s_Methods;

        #region effected by for cicle in ReadType method
        public static string s_TypeNamespace;
        //xml
        public static string s_ReturnValueXmlPath;
        public static XmlDocument s_ReturnValueXml;
        #endregion

        static Util()
        {
            s_CoreXamlSb = new StringBuilder();
            s_CoreXamlCsSb = new StringBuilder();
            s_CoreViewModelSb = new StringBuilder();

            s_TAB4 = "    ";
            s_TAB8 = "        ";
            s_TAB12 = "            ";
            s_TAB16 = "                ";
            s_TAB20 = "                    ";

            s_ToShortType = new Dictionary<string, string>();
            s_ToShortType.Add("Void", "void");
            s_ToShortType.Add("SByte", "sbyte");
            s_ToShortType.Add("Byte", "byte");
            s_ToShortType.Add("UInt16", "ushort");
            s_ToShortType.Add("Int16", "short");
            s_ToShortType.Add("UInt32", "uint");
            s_ToShortType.Add("Int32", "int");
            s_ToShortType.Add("UInt64", "ulong");
            s_ToShortType.Add("Int64", "long");
            s_ToShortType.Add("String", "string");
            s_ToShortType.Add("Boolean", "bool");
            s_ToShortType.Add("Single", "float");
            s_ToShortType.Add("Double", "double");
            s_ToShortType.Add("Object", "object");

            s_ExceptionsArray = new string[7];
            s_ExceptionsArray[0] = "Equals";
            s_ExceptionsArray[1] = "ReferenceEquals";
            s_ExceptionsArray[2] = "GetHashCode";
            s_ExceptionsArray[3] = "GetType";
            s_ExceptionsArray[4] = "ToString";
            s_ExceptionsArray[5] = "MemberwiseClone";
            s_ExceptionsArray[6] = "Discover";

            s_CurrentExeDirectory = System.IO.Directory.GetCurrentDirectory();

            s_Methods = new List<string>();
        }

        private static bool IsExceptionsArrayContains(string element)
        {
            if (s_ExceptionsArray == null)
            {
                return false;
            }

            for (int i = 0; i < s_ExceptionsArray.Length; i++)
            {
                if (s_ExceptionsArray[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        private static void LoadXml(string fileName)
        {
            string xmlDirectoryPath = s_CurrentExeDirectory + "\\" + s_TypeNamespace;
            string xmlFilePath = xmlDirectoryPath + "\\" + fileName + ".xml";
            s_ReturnValueXml = new XmlDocument();
            if (!System.IO.File.Exists(xmlFilePath))
            {
                string xmlContent = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                    "<" + fileName + ">\n" +
                    "</" + fileName + ">";
                System.IO.File.WriteAllText(xmlFilePath, xmlContent);
            }

            s_ReturnValueXmlPath = xmlFilePath;
            s_ReturnValueXml.Load(xmlFilePath);
        }

        private static string ReadValueXml(string functionName, string functionReturnType)
        {
            //find existing value
            XmlElement root = s_ReturnValueXml.DocumentElement;
            foreach (XmlNode node in root)
            {
                // получаем атрибут name
                if (node.Name == functionName)
                {
                    if (node.Attributes.Count > 0)
                    {
                        XmlNode attribute = node.Attributes.GetNamedItem("ReturnValue");
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }

            //if value is not exist -> create value
            var functionNode = s_ReturnValueXml.CreateElement(functionName);
            var functionNodeAttribute = s_ReturnValueXml.CreateAttribute("ReturnValue");
            switch (functionReturnType)
            {
                case "byte":
                case "sbyte":
                case "ushort":
                case "short":
                case "uint":
                case "int":
                {
                    functionNodeAttribute.Value = "64";
                    break;
                }
                case "float":
                {
                    functionNodeAttribute.Value = "3.14f";
                    break;
                }
                case "double":
                {
                    functionNodeAttribute.Value = "3.1415926535";
                    break;
                }
                case "string":
                {
                    functionNodeAttribute.Value = "string value";
                    break;
                }
                case "object":
                {
                    functionNodeAttribute.Value = "1234";
                    break;
                }
            }

            functionNode.Attributes.Append(functionNodeAttribute);

            root.AppendChild(functionNode);
            s_ReturnValueXml.Save(s_ReturnValueXmlPath);

            return functionNodeAttribute.Value;
        }

        private static void WriteUiView(string className, StringBuilder viewXamlSb, StringBuilder viewXamlCsSb)
        {
            var binDirectory = System.IO.Directory.GetParent(s_CurrentExeDirectory);
            var rootDirectory = System.IO.Directory.GetParent(binDirectory.Parent.FullName);
            var viewXamlPath = rootDirectory + "\\WpfDemo\\Views\\" + className + ".xaml";
            var viewXamlCsPath = rootDirectory + "\\WpfDemo\\Views\\" + className + ".xaml.cs";
            System.IO.File.WriteAllText(viewXamlPath, viewXamlSb.ToString());
            System.IO.File.WriteAllText(viewXamlCsPath, viewXamlCsSb.ToString());
        }

        private static void WriteUiViewModel(string className, StringBuilder viewModelSb)
        {
            var binDirectory = System.IO.Directory.GetParent(s_CurrentExeDirectory);
            var rootDirectory = System.IO.Directory.GetParent(binDirectory.Parent.FullName);
            var viewModelPath = rootDirectory + "\\WpfDemo\\ViewModels\\" + className + ".cs";
            System.IO.File.WriteAllText(viewModelPath, viewModelSb.ToString());
        }
        
        public static void ReadType(Type type)
        {
            string name = type.Name;
            string fullname = type.FullName;
            string fullNameWODots = fullname.Replace(".", "_");
            var methodInfos = type.GetMethods();
            
            var fullnameSplitted = fullname.Split('.');
            s_TypeNamespace = "";
            if (fullnameSplitted.Length == COMPONENTS_IN_PATH)
            {
                s_TypeNamespace = fullnameSplitted[NAMESPACE_INDEX_IN_PATH];
            }

            #region Create UI
            AppendCoreUI(s_TypeNamespace);
            CreateNamespaceUI(s_TypeNamespace, methodInfos);
            #endregion

            string directory = s_CurrentExeDirectory + "\\" + s_TypeNamespace;
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            StringBuilder interfaceSb = new StringBuilder();
            StringBuilder classSb = new StringBuilder();

            LoadXml(s_TypeNamespace);

            interfaceSb.AppendLine("using System.ServiceModel;");
            interfaceSb.AppendLine("");
            interfaceSb.AppendLine("namespace ServiceIntegrationMoq");
            interfaceSb.AppendLine("{");
            interfaceSb.AppendLine(s_TAB4 + "[ServiceContract]");
            interfaceSb.AppendLine(s_TAB4 + "public interface " + "I" + fullNameWODots);
            interfaceSb.AppendLine(s_TAB4 + "{");

            classSb.AppendLine("using System.ServiceModel;");
            classSb.AppendLine("");
            classSb.AppendLine("namespace ServiceIntegrationMoq");
            classSb.AppendLine("{");
            classSb.AppendLine(s_TAB4 + "public class " + fullNameWODots + " : I" + name + ", " + fullname);
            classSb.AppendLine(s_TAB4 + "{");

            for (int i = 0; i < methodInfos.Length; i++)
            {
                var methodInfo = methodInfos[i];
                string accessModifier;
                string returnType = methodInfo.ReturnType.Name;
                string returnCode;

                if (methodInfo.IsVirtual || 
                    methodInfo.IsPrivate ||
                    (methodInfo.Name[0] == methodInfo.Name.ToLower()[0]) ||
                    IsExceptionsArrayContains(methodInfo.Name))
                {
                    continue;
                }

                if (s_Methods.Contains(methodInfo.Name))
                {
                    continue;
                }
                else
                {
                    s_Methods.Add(methodInfo.Name);
                }
                
                if (methodInfo.IsPublic)
                {
                    accessModifier = "public";
                }
                else if (methodInfo.IsPrivate)
                {
                    accessModifier = "private";
                }
                else
                {
                    accessModifier = "protected";
                }

                if (s_ToShortType.ContainsKey(returnType))
                {
                    returnType = s_ToShortType[methodInfo.ReturnType.Name];
                }

                /*read xml file there*/
                string returnValue = ReadValueXml(methodInfo.Name, returnType);
                switch (returnType)
                {
                    case "void": { returnCode = "/* Nothing to return */"; break; }
                    case "string": { returnCode = "return \"" + returnValue + "\";"; break; }
                    default: { returnCode = "return " + returnValue + ";"; break; }
                }

                interfaceSb.AppendLine(s_TAB8 + "[OperationContract]");
                interfaceSb.Append(s_TAB8 + returnType + " " + methodInfo.Name + "(");
                classSb.Append(s_TAB8 + accessModifier + " " + returnType + " " + methodInfo.Name + "(");

                var parameters = methodInfo.GetParameters();
                for (int p = 0; p < parameters.Length; p++)
                {
                    var parameter = parameters[p];
                    var parameterName = parameter.Name;
                    var parameterTypeName = parameter.ParameterType.Name;

                    if (s_ToShortType.ContainsKey(parameterTypeName))
                    {
                        parameterTypeName = s_ToShortType[parameterTypeName];
                    }

                    interfaceSb.Append(parameterTypeName + " " + parameterName);
                    classSb.Append(parameterTypeName + " " + parameterName);
                    if (p != (parameters.Length - 1))
                    {
                        interfaceSb.Append(", ");
                        classSb.Append(", ");
                    }
                }
                
                interfaceSb.AppendLine(");");
                interfaceSb.AppendLine();

                classSb.AppendLine(")");
                classSb.AppendLine(s_TAB8 + "{");
                classSb.AppendLine(s_TAB12 + returnCode);
                classSb.AppendLine(s_TAB8 + "}");
                classSb.AppendLine();

            }

            interfaceSb.AppendLine(s_TAB4 + "}");
            interfaceSb.AppendLine("}");

            classSb.AppendLine(s_TAB4 + "}");
            classSb.Append("}");

            string currentInterfacePath = directory + "\\I" + name + ".cs";
            string currentClassPath     = directory + "\\" + name + ".cs";

            System.IO.File.WriteAllText(currentInterfacePath, interfaceSb.ToString());
            System.IO.File.WriteAllText(currentClassPath, classSb.ToString());

        }

        public static void BeginCreateCoreUI()
        {
            if (!CreateUI)
            {
                return;
            }

            #region Core ui xaml
            s_CoreXamlSb.AppendLine("<Window x:Class=\"WPFDemo.Views.MainView\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "xmlns:local=\"clr-namespace:WPFDemo.ViewModels\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "mc:Ignorable=\"d\"");
            s_CoreXamlSb.AppendLine(s_TAB4 + "Title=\"MainView\" Height=\"720\" Width=\"1280\">");
            
            s_CoreXamlSb.AppendLine();
            
            s_CoreXamlSb.AppendLine(s_TAB4 + "<Window.DataContext>");
            s_CoreXamlSb.AppendLine(s_TAB8 + "<local:MainViewModel/>");
            s_CoreXamlSb.AppendLine(s_TAB4 + "</Window.DataContext>");
            
            s_CoreXamlSb.AppendLine();
            
            s_CoreXamlSb.AppendLine(s_TAB4 + "<Grid>");
            s_CoreXamlSb.AppendLine(s_TAB8 + "<Grid.RowDefinitions>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<RowDefinition Height=\"2*\"/>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<RowDefinition Height=\"*\"/>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<RowDefinition Height=\"30*\"/>");
            s_CoreXamlSb.AppendLine(s_TAB8 + "</Grid.RowDefinitions>");
            s_CoreXamlSb.AppendLine();
            s_CoreXamlSb.AppendLine(s_TAB8 + "<Grid.ColumnDefinitions>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition/>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition/>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition/>");
            s_CoreXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition/>");
            s_CoreXamlSb.AppendLine(s_TAB8 + "</Grid.ColumnDefinitions>");
            s_CoreXamlSb.AppendLine();
            s_CoreXamlSb.AppendLine(s_TAB8 + "<Button Grid.Row=\"0\" Grid.Column=\"2\" Margin=\"10\" Content=\"Save return values\"/>");
            s_CoreXamlSb.AppendLine(s_TAB8 + "<Button Grid.Row=\"0\" Grid.Column=\"3\" Margin=\"10\" Content=\"Recreate services\"/>");
            s_CoreXamlSb.AppendLine();
            s_CoreXamlSb.AppendLine(s_TAB8 + "<StackPanel Grid.Row=\"1\" Grid.Column=\"0\" Grid.ColumnSpan=\"2\" Orientation=\"Horizontal\" CanHorizontallyScroll=\"True\">");
            #endregion

            #region Core ui xaml.cs
            s_CoreXamlCsSb.AppendLine("using System.Windows;");
            s_CoreXamlCsSb.AppendLine();
            s_CoreXamlCsSb.AppendLine("");
            s_CoreXamlCsSb.AppendLine("namespace WPFDemo.Views");
            s_CoreXamlCsSb.AppendLine("{");
            s_CoreXamlCsSb.AppendLine(s_TAB4 + "public partial class MainView : Window");
            s_CoreXamlCsSb.AppendLine(s_TAB4 + "{");
            s_CoreXamlCsSb.AppendLine(s_TAB8 + "public MainView()");
            s_CoreXamlCsSb.AppendLine(s_TAB8 + "{");
            s_CoreXamlCsSb.AppendLine(s_TAB12 + "InitializeComponent();");
            s_CoreXamlCsSb.AppendLine(s_TAB8 + "}");
            s_CoreXamlCsSb.AppendLine(s_TAB4 + "}");
            s_CoreXamlCsSb.AppendLine("}");
            #endregion

            #region Core viewmodel
            s_CoreViewModelSb.AppendLine("using System.Windows.Controls;");
            s_CoreViewModelSb.AppendLine("using WPFDemo.Models;");
            
            s_CoreViewModelSb.AppendLine();
            
            s_CoreViewModelSb.AppendLine("namespace WPFDemo.ViewModels");
            s_CoreViewModelSb.AppendLine("{");
            s_CoreViewModelSb.AppendLine(s_TAB4 + "public class MainViewModel : ViewModelBase");
            s_CoreViewModelSb.AppendLine(s_TAB4 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "private ContentControl m_ContentField;");
            
            s_CoreViewModelSb.AppendLine();
            
            s_CoreViewModelSb.AppendLine(s_TAB8 + "public MainViewModel()");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "m_ContentField = new Views.DemoView();");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "}");
            
            s_CoreViewModelSb.AppendLine();
            
            s_CoreViewModelSb.AppendLine(s_TAB8 + "public ContentControl ContentField");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "get { return m_ContentField; }");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "set");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB16 + "m_ContentField = value;");
            s_CoreViewModelSb.AppendLine(s_TAB16 + "OnPropertyChanged();");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "}");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "}");
            s_CoreViewModelSb.AppendLine();
            #endregion
        }

        public static void AppendCoreUI(string namespaceName)
        {
            if (!CreateUI)
            {
                return;
            }

            #region Core ui xaml
            s_CoreXamlSb.AppendLine(s_TAB16 + "<Button Margin=\"5 0 0 0\" Name=\"btn" + namespaceName + "\" Content=\"" + namespaceName + "\" Command=\"{Binding btn" + namespaceName + "_Click}\"/>");
            #endregion

            #region Core viewmodel
            s_CoreViewModelSb.AppendLine(s_TAB8 + "public RelayCommand btn" + namespaceName + "_Click");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "get");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB16 + "return new RelayCommand((obj) =>");
            s_CoreViewModelSb.AppendLine(s_TAB16 + "{");
            s_CoreViewModelSb.AppendLine(s_TAB20 + "ContentField = new Views." + namespaceName + "View();");
            s_CoreViewModelSb.AppendLine(s_TAB16 + "});");
            s_CoreViewModelSb.AppendLine(s_TAB12 + "}");
            s_CoreViewModelSb.AppendLine(s_TAB8 + "}");
            s_CoreViewModelSb.AppendLine();
            #endregion
        }

        public static void EndCreateCoreUI()
        {
            if (!CreateUI)
            {
                return;
            }

            #region Core ui xaml
            s_CoreXamlSb.AppendLine(s_TAB8 + "</StackPanel>");
            s_CoreXamlSb.AppendLine();
            s_CoreXamlSb.AppendLine(s_TAB8 + "<ContentControl ");
            s_CoreXamlSb.AppendLine(s_TAB12 + "Grid.Row=\"2\" Grid.Column=\"0\" Grid.ColumnSpan=\"2\" ");
            s_CoreXamlSb.AppendLine(s_TAB12 + "MinWidth=\"1200\"");
            s_CoreXamlSb.AppendLine(s_TAB12 + "HorizontalAlignment=\"Center\"");
            s_CoreXamlSb.AppendLine(s_TAB12 + "Content=\"{Binding ContentField, UpdateSourceTrigger = PropertyChanged}\"/>");
            s_CoreXamlSb.AppendLine();
            s_CoreXamlSb.AppendLine(s_TAB4 + "</Grid>");
            s_CoreXamlSb.AppendLine();
            s_CoreXamlSb.AppendLine(s_TAB4 + "</Window>");

            WriteUiView("MainView", s_CoreXamlSb, s_CoreXamlCsSb);

            #endregion

            #region Core viewmodel
            s_CoreViewModelSb.AppendLine(s_TAB4 + "}");
            s_CoreViewModelSb.AppendLine("}");

            WriteUiViewModel("MainViewModel", s_CoreViewModelSb);

            #endregion

        }

        public static void CreateNamespaceUI(string namespaceName, MethodInfo[] methodInfos)
        {
            if (!CreateUI)
            {
                return;
            }

            string className = namespaceName + "View";

            #region View.xaml
            s_NamespaceViewXamlSb.AppendLine("<UserControl x:Class=\"WPFDemo.Views." + className + "\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "xmlns:local=\"clr-namespace:WPFDemo.Views\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "mc:Ignorable=\"d\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "d:DesignHeight=\"720\" d:DesignWidth=\"1280\">");
            s_NamespaceViewXamlSb.AppendLine(s_TAB4 + "<Grid>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB4 + "<!--MainCode-->");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "<Grid.RowDefinitions>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<RowDefinition Height=\"1*\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<RowDefinition Height=\"15*\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "</Grid.RowDefinitions>");
            s_NamespaceViewXamlSb.AppendLine();
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "</Grid.ColumnDefinitions>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition Width=\"0.3*\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition Width=\"0.6*\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<ColumnDefinition Width=\"0.1*\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "</Grid.ColumnDefinitions>");
            s_NamespaceViewXamlSb.AppendLine();
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "<TextBlock Grid.Row=\"0\" Grid.Column=\"0\" Width=\"1000\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "TextAlignment=\"Center\" HorizontalAlignment=\"Center\"");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "Background=\"Green\" FontSize=\"30\" Grid.ColumnSpan=\"2\">");
            s_NamespaceViewXamlSb.AppendLine(s_TAB16 + className);
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "</TextBlock>");
            s_NamespaceViewXamlSb.AppendLine();
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "<StackPanel Grid.Row=\"1\" Grid.Column=\"0\" Background=\"LightGoldenrodYellow\" Orientation=\"Vertical\">");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<TextBlock Text=\"Поиск\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<StackPanel Orientation=\"Horizontal\">");
            s_NamespaceViewXamlSb.AppendLine(s_TAB16 + "<TextBox Width=\"150\" Text=\"Введите имя функции\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB16 + "<Button Width=\"50\" Content=\"Искать\"/>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "</StackPanel>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "</StackPanel>");
            s_NamespaceViewXamlSb.AppendLine();
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "<ScrollViewer Grid.Row=\"1\" Grid.Column=\"1\" Width=\"550\" Margin=\"5\" Background=\"Red\" VerticalAlignment=\"Top\" VerticalScrollBarVisibility=\"Visible\">");
            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "<StackPanel  Width=\"500\" Grid.Row=\"1\" Orientation=\"Vertical\" HorizontalAlignment=\"Center\">");

            //all method info shit
            for (int m = 0; m < methodInfos.Length; m++)
            {
                var methodInfo = methodInfos[m];
                s_NamespaceViewXamlSb.AppendLine(s_TAB16 + "<StackPanel Orientation=\"Horizontal\">");
                s_NamespaceViewXamlSb.AppendLine(s_TAB20 + "<Label Width=\"150\" Content=\"First\"/>");
                s_NamespaceViewXamlSb.AppendLine(s_TAB20 + "<Label Width=\"150\" Content=\"bReturn\"/>");
                s_NamespaceViewXamlSb.AppendLine(s_TAB20 + "<TextBox Width=\"150\" Text=\"2.3\"/>");
                s_NamespaceViewXamlSb.AppendLine(s_TAB16 + "</StackPanel>");
            }

            s_NamespaceViewXamlSb.AppendLine(s_TAB12 + "</StackPanel>");
            s_NamespaceViewXamlSb.AppendLine(s_TAB8 + "</ScrollViewer>");
            s_NamespaceViewXamlSb.AppendLine();

            s_NamespaceViewXamlSb.AppendLine(s_TAB4 + "</Grid>");
            s_NamespaceViewXamlSb.AppendLine("</UserControl>");
            #endregion

            #region View.xaml.cs
            s_NamespaceViewXamlCsSb.AppendLine("using System.Windows.Controls;");
            s_NamespaceViewXamlCsSb.AppendLine();
            s_NamespaceViewXamlCsSb.AppendLine("namespace WPFDemo.Views");
            s_NamespaceViewXamlCsSb.AppendLine("{");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB4 + "public partial class " + className + " : UserControl");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB4 + "{");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB8 + "public " + className + "()");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB8 + "{");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB12 + "InitializeComponent();");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB8 + "}");
            s_NamespaceViewXamlCsSb.AppendLine(s_TAB4 + "}");
            s_NamespaceViewXamlCsSb.AppendLine("}");
            #endregion

            WriteUiView(className, s_NamespaceViewXamlSb, s_NamespaceViewXamlCsSb);

            s_NamespaceViewXamlSb.Clear();
            s_NamespaceViewXamlCsSb.Clear();
        }

        public static void StartUI()
        {
            if (!RunUI)
            {
                return;
            }

            var thread = new Thread(() => 
            {
                var mainView = new WPFDemo.Views.MainView();
                System.Windows.Application app = new System.Windows.Application();
                app.Run(mainView);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }

    class Program
    {
        private enum OrderType
        {
            CreateUI = 0, RunUI, CreateAndRunUI
        }

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Work!");

            OrderType orderType = OrderType.RunUI;

            switch (orderType)
            {
                case OrderType.CreateUI: { Util.CreateUI = true; Util.RunUI = false; break; }
                case OrderType.RunUI: { Util.CreateUI = false; Util.RunUI = true; break; }
                case OrderType.CreateAndRunUI: { Util.CreateUI = true; Util.RunUI = true; break; }
                default: { Util.CreateUI = false; Util.RunUI = false; break; }
            }

            Util.BeginCreateCoreUI();

            Util.ReadType(typeof(ServiceIntegration.wsArm.IAPO2_ARM_READERservice));
            Util.ReadType(typeof(ServiceIntegration.wsArmProxy.IAPO2_ARM_READERservice));
            Util.ReadType(typeof(ServiceIntegration.wsRsaBso.IIBD_RSA_WebServservice));
            
            Util.EndCreateCoreUI();

            Util.StartUI();

            Console.ReadLine();
        }
    }
}
