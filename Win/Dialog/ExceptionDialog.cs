using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace EBAP.Win.Dialog
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class ExceptionDialog : DevExpress.XtraEditors.XtraForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Exception Form 생성합니다.
        /// </summary>
        public ExceptionDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private string[] replaceEmptyList = new string[]{ "System.Web.Services.Protocols.SoapException:",
                                                          "System.Data.SqlClient.SqlException:" };

        private const int _stdFormWidth = 800;
        private const int _stdFormHeight = 600;

        //private int _height = 575;
        private int _detailHeight = 340;

        private DateTime _exceptionTime;

        private bool _enlarged = false;
        private bool _detailVisible = false;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Exception :: 예외를 설정합니다.

        /// <summary>
        /// 예외를 설정합니다.
        /// </summary>
        [Browsable(false)]
        public Exception Except
        {
            get;
            set;
        }

        #endregion

        #region :: IsAdmin :: 관리자 권한을 설정합니다.

        /// <summary>
        /// 관리자 권한을 설정합니다.
        /// </summary>
        [Browsable(false)]
        public bool IsAdmin
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: HideDetail :: Detail 구간을 숨김니다.

        /// <summary>
        /// Detail 구간을 숨김니다.
        /// </summary>
        private void HideDetail()
        {
            _detailVisible = false;
            txtDetail.Visible = false;
            btnReport.Visible = false;
            btnCopy.Visible = false;
            btnCopy.Enabled = false;

            btnResize.Visible = false;
            btnResize.Enabled = false;
            btnExit.Visible = false;
            btnExit.Enabled = false;
            btnDetail.Text = "자세히 >>";

            Height = Height - _detailHeight - btnCopy.Height - 16;
        }

        #endregion

        #region :: ShowDetail :: Detail 구간을 보입니다.

        /// <summary>
        /// Detail 구간을 보입니다.
        /// </summary>
        private void ShowDetail()
        {
            Height = Height + _detailHeight + btnCopy.Height + 16;

            _detailVisible = true;
            txtDetail.Visible = true;
            //btnReport.Visible = true;
            btnCopy.Visible = true;
            btnCopy.Enabled = true;

            btnResize.Visible = true;
            btnResize.Enabled = true;
            btnExit.Visible = false;
            btnExit.Enabled = false;
            btnDetail.Text = "자세히 <<";
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Load Event ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmException_Load(object sender, EventArgs e)
        {
            if (Except == null)
                Except = new Exception("표시할 예외 정보가 없어요.");

            btnDetail.Visible = IsAdmin;

            _exceptionTime = DateTime.Now;
            Text = String.Format("예외발생 - {0}", _exceptionTime.ToString("yyyy-MM-dd HH:mm:ss"));

            string exMessage = Except.Message.Replace("\n", Environment.NewLine);
            exMessage = exMessage.Replace("--->", $"{Environment.NewLine}{Environment.NewLine}");

            int idx = exMessage.IndexOf("위치");
            exMessage = exMessage.Substring(0, idx < 0 ? exMessage.Length : idx);

            foreach(string rep in replaceEmptyList)
            {
                exMessage = exMessage.Replace(rep, "");
            }

            txtDesc.Text = exMessage;

            StringBuilder callStack = new StringBuilder();

            GetCallStack(Except, ref callStack);

            txtDetail.Text = callStack.ToString();

            HideDetail();
        }

        /// <summary>
        /// Exception의 Inner Exception을 Call Stack에 담습니다.
        /// </summary>
        /// <param name="_exception"></param>
        /// <param name="callStack"></param>
        private void GetCallStack(Exception _exception, ref StringBuilder callStack)
        {
            if (_exception == null)
                return;

            //callStack.AppendLine(_exception.Message);
            callStack.AppendLine(_exception.StackTrace);
            GetCallStack(_exception.InnerException, ref callStack);
        }

        #endregion

        #region : Ok Button Click Event :

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region : Detail Button Click Event :

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (_detailVisible)
                HideDetail();
            else
                ShowDetail();
        }

        #endregion

        #region : Clipboard Button Click Event :

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtDetail.SelectAll();
            txtDetail.Copy();
        }

        #endregion

        #region : Report Button Click Event :

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            //TODO: 서버에 오류를 전송할 수 있는 로직 만들기!(긴급도 100)
        }

        #endregion

        #region : Resize Button Click Event :

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResize_Click(object sender, EventArgs e)
        {
            if (_enlarged)
            {
                Width = _stdFormWidth;
                Height = _stdFormHeight;
                btnResize.Text = "크게";
                _enlarged = false;
            }
            else
            {
                Width = _stdFormWidth + _stdFormWidth / 2;
                Height = _stdFormHeight + _stdFormHeight / 2;
                btnResize.Text = "작게";
                _enlarged = true;
            }

            int x = 0;
            int y = 0;

            x = (Screen.GetBounds(this).Width / 2) - (Width / 2);
            y = (Screen.GetBounds(this).Height / 2) - (Height / 2);

            _detailHeight = txtDetail.Height;

            SetBounds(x, y, Width, Height, BoundsSpecified.Location);
        }

        #endregion

        #region : Exit Button Click Event :

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        #endregion
    }
}