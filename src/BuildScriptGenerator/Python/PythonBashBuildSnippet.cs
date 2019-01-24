// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.Oryx.BuildScriptGenerator.Python
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class PythonBashBuildSnippet : PythonBashBuildSnippetBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\ndeclare -r TS_FMT=\'[%T%z] \'\ndeclare -r REQS_NOT_FOUND_MSG=\'Could not find requir" +
                    "ements.txt; Not running pip install\'\n\necho \"Python Version: $python\"\ncd \"$SOURCE" +
                    "_DIR\"\n\n");
            
            #line 7 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"

	if (!string.IsNullOrWhiteSpace(VirtualEnvironmentName)) {

            
            #line default
            #line hidden
            this.Write("\nVIRTUALENVIRONMENTNAME=");
            
            #line 10 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(VirtualEnvironmentName));
            
            #line default
            #line hidden
            this.Write("\nVIRTUALENVIRONMENTMODULE=");
            
            #line 11 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(VirtualEnvironmentModule));
            
            #line default
            #line hidden
            this.Write("\nVIRTUALENVIRONMENTOPTIONS=");
            
            #line 12 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(VirtualEnvironmentParameters));
            
            #line default
            #line hidden
            this.Write(@"

echo ""Python Virtual Environment: $VIRTUALENVIRONMENTNAME""

echo Creating virtual environment ...
$python -m $VIRTUALENVIRONMENTMODULE $VIRTUALENVIRONMENTNAME $VIRTUALENVIRONMENTOPTIONS

echo Activating virtual environment ...
source $VIRTUALENVIRONMENTNAME/bin/activate

if [ -e ""requirements.txt"" ]
then
	pip install --upgrade pip
	pip install --prefer-binary -r requirements.txt | ts $TS_FMT
else
	echo $REQS_NOT_FOUND_MSG
fi

# For virtual environment, we use the actual 'python' alias that as setup by the venv,
python_bin=python
");
            
            #line 32 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"

	}
	else {

            
            #line default
            #line hidden
            this.Write("\nif [ -e \"requirements.txt\" ]\nthen\n\t# Indent the output as pip install prints the" +
                    " \'Successfully Installed...\' message and then waits which can confuse an end use" +
                    "r.\n\techo Running pip install...\n\n\t$pip install --prefer-binary -r requirements.t" +
                    "xt --target=\"");
            
            #line 40 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackagesDirectory));
            
            #line default
            #line hidden
            this.Write(@""" --upgrade | ts $TS_FMT
	pipInstallExitCode=${PIPESTATUS[0]}

	if [[ $pipInstallExitCode != 0 ]]
	then
		exit $pipInstallExitCode
	fi
else
	echo $REQS_NOT_FOUND_MSG
fi

# We need to use the python binary selected by benv
python_bin=$python

# Detect the location of the site-packages to add the .pth file
# For the local site package, only major and minor versions are provided, so we fetch it again
SITE_PACKAGE_PYTHON_VERSION=$($python -c ""import sys; print(str(sys.version_info.major) + '.' + str(sys.version_info.minor))"")
SITE_PACKAGES_PATH=$HOME""/.local/lib/python""$SITE_PACKAGE_PYTHON_VERSION""/site-packages""
mkdir -p $SITE_PACKAGES_PATH
# To make sure the packages are available later, e.g. for collect static or post-build hooks, we add a .pth pointing to them
APP_PACKAGES_PATH=$(pwd)""/");
            
            #line 59 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(PackagesDirectory));
            
            #line default
            #line hidden
            this.Write("\"\necho $APP_PACKAGES_PATH > $SITE_PACKAGES_PATH\"/oryx.pth\"\n\n");
            
            #line 62 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"

	}

            
            #line default
            #line hidden
            this.Write("echo Done running pip install.\r\n\r\n");
            
            #line 67 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"

	if (!DisableCollectStatic) {

            
            #line default
            #line hidden
            this.Write(@"if [ -e ""$SOURCE_DIR/manage.py"" ]
then
	if grep -iq ""Django"" ""$SOURCE_DIR/requirements.txt""
	then
		echo
		echo Content in source directory is a Django app
		echo Running 'collectstatic' ...
		$python_bin manage.py collectstatic --noinput || EXIT_CODE=$? && true ; 
		echo ""'collectstatic' exited with exit code $EXIT_CODE.""
	fi
fi
");
            
            #line 81 "C:\Oryx\src\BuildScriptGenerator\Python\PythonBashBuildSnippet.tt"

	}

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class PythonBashBuildSnippetBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}