using DevExpress.XtraPrinting.BarCode;
using System.ComponentModel;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Barcode Control 입니다.
    /// DevExpress BarCodeControl을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PBarCodeControl : DevExpress.XtraEditors.BarCodeControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SimpleButton Control을 생성합니다.
        /// </summary>
        public PBarCodeControl()
        {
            InitializeComponent();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Attribute 
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: EqualControlNextSeq :: 동일한 Type의 컨트롤 다음 Seq를 반환합니다.

        /// <summary>
        /// 동일한 Type의 컨트롤 다음 Seq를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("동일한 Type의 컨트롤 다음 Seq를 반환합니다.")]
        public int EqualControlNextSeq
        {
            get;
            set;
        }

        #endregion

        #region :: EqualTotalControlNextSeq :: 종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.

        /// <summary>
        /// 종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.")]
        public int EqualTotalControlNextSeq
        {
            get;
            set;
        }

        /// <summary>
        /// 라벨 공통 Name값을 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("라벨 공통 Name값")]
        public object EditValue
        {
            get;
            set;
        }

        #endregion

        #region :: ChangeBarCodeGenerator :: 바코드 형식을 변경합니다.

        /// <summary>
        /// 바코드 형식을 변경합니다.
        /// </summary>
        /// <param name="barcodeType">바코드 형식</param>
        public void ChangeBarCodeGenerator(string barcodeType)
        {
            string tempText = Text;
            BarCodeGeneratorBase barCodeBase = GetBarCodeType(barcodeType) as BarCodeGeneratorBase;

            if (barCodeBase == null) return;

            Text = "";
            Refresh();
            Symbology = barCodeBase;

            Symbology.CalcCheckSum = false;
            this.

            UpdateStyles();

            Text = tempText;
            Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BarcodeType"></param>
        /// <returns></returns>
        private object GetBarCodeType(string BarcodeType)
        {
            object ResultClass;

            switch (BarcodeType)
            {
                case "Code128":
                    ResultClass = new DevExpress.XtraPrinting.BarCode.Code128Generator();
                    (ResultClass as DevExpress.XtraPrinting.BarCode.Code128Generator).CharacterSet = Code128Charset.CharsetAuto;
                    break;
                case "Code39":
                    ResultClass = new DevExpress.XtraPrinting.BarCode.Code39Generator();
                    break;
                case "QRCode":
                    ResultClass = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
                    (ResultClass as DevExpress.XtraPrinting.BarCode.QRCodeGenerator).CompactionMode = QRCodeCompactionMode.Byte;
                    break;
                case "DataMatrix":
                    ResultClass = new DevExpress.XtraPrinting.BarCode.DataMatrixGenerator();
                    break;
                default:
                    ResultClass = new DevExpress.XtraPrinting.BarCode.Code128Generator();
                    break;
            }

            return ResultClass;

        }

        #endregion
    }
}
