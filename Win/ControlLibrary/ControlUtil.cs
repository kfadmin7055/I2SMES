using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraVerticalGrid.Rows;
using EBAP.Core.Info;
using EBAP.Win.ControlLibrary.Repository;
using EBAP.Win.Utility;
using System.Data;
using System.Drawing;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Control Library에서 사용할 Util Method를 정의합니다.
    /// </summary>
    public static class ControlUtil
    {
        #region :: CreateColumn :: LookUpColumn을 만듭니다.

        /// <summary>
        /// LookUpColumn을 만듭니다.
        /// </summary>
        /// <param name="fieldName">Field 명</param>
        /// <param name="caption">Column Caption 명</param>
        /// <param name="width">Column 너비</param>
        /// <param name="align">Column 정렬</param>
        /// <param name="visible">Column 숨김/보임</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        internal static LookUpColumnInfo CreateLookUpColumn(string fieldName, string caption, int width, HorzAlignment align, bool visible)
        {
            LookUpColumnInfo column = new LookUpColumnInfo { FieldName = fieldName, Caption = caption, Width = width, Alignment = align, Visible = visible };

            return column;
        }

        #endregion

        #region :: MakeComboBoxCell(+1 Overloading) :: ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeComboBoxCell(object[] valueList, string[] displayList)
        {
            return MakeComboBoxCell(valueList, displayList, false, false);
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeComboBoxCell(object[] valueList, string[] displayList, bool selectAllItemVisible, bool showCodeColumn)
        {
            if (valueList.Length != displayList.Length)
                return null;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx].ToString().Trim();
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx].Trim();
                    dt.Rows.Add(dr);
                }
                return MakeComboBoxCell(dt, selectAllItemVisible, showCodeColumn);
            }
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <returns></returns>
        public static RepositoryItem MakeComboBoxCell(DataTable dt)
        {
            return MakeComboBoxCell(dt, false, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <returns></returns>
        public static RepositoryItem MakeComboBoxCell(DataTable dt, bool selectAllItemVisible, bool showCodeColumn)
        {
            return MakeComboBoxCell(dt, selectAllItemVisible, showCodeColumn, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <returns></returns>
        public static RepositoryItem MakeComboBoxCell(DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            //RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            //DataRow dr;
            //if (selectAllItemVisible)
            //{
            //    dr = dt.NewRow();

            //    if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
            //        dr[valueMember] = "";
            //    else
            //        dr[valueMember] = -1;

            //    dr[displayMember] = "전체";
            //    dt.Rows.InsertAt(dr, 0);
            //}

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.NullText = "";
            //edit.DataSource = dt;
            //edit.ValueMember = valueMember;
            //edit.DisplayMember = displayMember;

            //edit.Columns.Add(CreateLookUpColumn(valueMember, valueMember, 70, HorzAlignment.Center, showCodeColumn));
            //edit.Columns.Add(CreateLookUpColumn(displayMember, displayMember, 120, HorzAlignment.Default, true));

            //edit.ShowHeader = false;
            //edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            //return edit;
            return RepositoryItemEditor.ComboBoxEdit(dt, selectAllItemVisible, showCodeColumn, valueMember, displayMember);
        }

        #endregion

        #region :: MakeCheckedComboBoxCell(+1 Overloading) :: Checked ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// Checked ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeCheckedComboBoxCell(object[] valueList, string[] displayList)
        {
            return MakeCheckedComboBoxCell(valueList, displayList, false, false);
        }

        /// <summary>
        /// Checked ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeCheckedComboBoxCell(object[] valueList, string[] displayList, bool selectAllItemVisible, bool showCodeColumn)
        {
            if (valueList.Length != displayList.Length)
                return null;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx].ToString().Trim();
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx].Trim();
                    dt.Rows.Add(dr);
                }
                return MakeCheckedComboBoxCell(dt, selectAllItemVisible);
            }
        }

        /// <summary>
        /// Checked ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <returns></returns>
        public static RepositoryItem MakeCheckedComboBoxCell(DataTable dt)
        {
            return MakeCheckedComboBoxCell(dt, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// Checked ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <returns></returns>
        public static RepositoryItem MakeCheckedComboBoxCell(DataTable dt, bool selectAllItemVisible)
        {
            return MakeCheckedComboBoxCell(dt, selectAllItemVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// Checked ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <returns></returns>
        public static RepositoryItem MakeCheckedComboBoxCell(DataTable dt, bool selectAllItemVisible, string valueMember, string displayMember)
        {
            //RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            //DataRow dr;
            //if (selectAllItemVisible)
            //{
            //    dr = dt.NewRow();

            //    if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
            //        dr[valueMember] = "";
            //    else
            //        dr[valueMember] = -1;

            //    dr[displayMember] = "전체";
            //    dt.Rows.InsertAt(dr, 0);
            //}

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.NullText = "";
            //edit.DataSource = dt;
            //edit.ValueMember = valueMember;
            //edit.DisplayMember = displayMember;

            //edit.Columns.Add(CreateLookUpColumn(valueMember, valueMember, 70, HorzAlignment.Center, showCodeColumn));
            //edit.Columns.Add(CreateLookUpColumn(displayMember, displayMember, 120, HorzAlignment.Default, true));

            //edit.ShowHeader = false;
            //edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            //return edit;

            return RepositoryItemEditor.CheckedComboBoxEdit(dt, selectAllItemVisible, valueMember, displayMember);
        }

        #endregion

        #region :: MakeRadioGroupCell(+1 Overloading) :: Radio Group Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// Radio Group Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeRadioGroupCell(object[] valueList, string[] displayList)
        {
            return MakeRadioGroupCell(valueList, displayList, false, false);
        }

        /// <summary>
        /// Radio Group Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2016-07-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeRadioGroupCell(object[] valueList, string[] displayList, bool selectAllItemVisible, bool showCodeColumn)
        {
            if (valueList.Length != displayList.Length)
                return null;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx].ToString().Trim();
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx].Trim();
                    dt.Rows.Add(dr);
                }
                return MakeRadioGroupCell(dt, selectAllItemVisible, showCodeColumn);
            }
        }

        /// <summary>
        /// Radio Group Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <returns></returns>
        public static RepositoryItem MakeRadioGroupCell(DataTable dt)
        {
            return MakeRadioGroupCell(dt, false, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// Radio Group Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <returns></returns>
        public static RepositoryItem MakeRadioGroupCell(DataTable dt, bool selectAllItemVisible, bool showCodeColumn)
        {
            return MakeRadioGroupCell(dt, selectAllItemVisible, showCodeColumn, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// Radio Group Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <returns></returns>
        public static RepositoryItem MakeRadioGroupCell(DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            //RepositoryItemRadioGroup edit = new RepositoryItemRadioGroup();

            //DataRow dr;

            //if (selectAllItemVisible)
            //{
            //    dr = dt.NewRow();

            //    if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
            //        dr[valueMember] = "";
            //    else
            //        dr[valueMember] = -1;

            //    dr[displayMember] = "전체";
            //    dt.Rows.InsertAt(dr, 0);
            //}

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.NullText = "";

            //foreach (DataRow drs in dt.Rows)
            //{
            //    RadioGroupItem rgi = new RadioGroupItem { Value = drs[valueMember], Description = drs[displayMember].ToString() };
            //    edit.Items.Add(rgi);
            //}

            //return edit;
            return RepositoryItemEditor.RadioGroupEdit(dt, selectAllItemVisible, showCodeColumn, valueMember, displayMember);
        }

        #endregion

        #region :: MakeTextEditCell :: Text Edit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// Text Edit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <returns></returns>
        public static RepositoryItem MakeTextEditCell()
        {
            return MakeTextEditCell(0);
        }

        /// <summary>
        /// Text Edit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static RepositoryItem MakeTextEditCell(int maxLength)
        {
            return RepositoryItemEditor.TextEdit(maxLength);
        }

        #endregion

        #region :: MakeSpinEditCell :: SpinEdit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// SpinEdit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <returns></returns>
        public static RepositoryItem MakeSpinEditCell()
        {
            //RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ////edit.Mask.EditMask = "n" + decimalPlace;
            ////edit.MaxLength = maxLength;
            //edit.Mask.UseMaskAsDisplayFormat = false;

            //return edit;

            //return MakeSpinEditCell(0, 0);

            return RepositoryItemEditor.SpinEdit(0, 0);
        }

        /// <summary>
        /// SpinEdit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="decimalPlace"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static RepositoryItem MakeSpinEditCell(int decimalPlace, int maxLength)
        {
            //RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //edit.Appearance.TextOptions.HAlignment = hAlignment;

            //return edit;

            return RepositoryItemEditor.SpinEdit(decimalPlace, maxLength);
        }

        #endregion

        #region :: ShowImageForm :: 이미지 Form을 보여줍니다.

        /// <summary>
        /// 이미지 Form을 보여줍니다.
        /// </summary>
        public static void ShowImageForm(byte[] imageData)
        {
            using (ImageForm imgForm = new ImageForm { Text = "Image Viewer", ImageData = imageData })
            {
                Image img = AppUtil.GetImageFromBinary(imageData);

                if (img != null)
                {
                    imgForm.Height = img.Height + 50;
                    imgForm.Width = img.Width + 20;
                }

                imgForm.ShowDialog();
            }
        }

        #endregion

        #region :: SetColumnType :: Column의 DataType을 정의합니다.

        /// <summary>
        /// Column의 DataType을 정의합니다.
        /// </summary>
        /// <param name="treeColumn">Grid Column</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        internal static void SetColumnType(TreeListColumn treeColumn, DataType dataType, int maxLength, int decimalPlace)
        {
            switch (dataType)
            {
                case DataType.Memo:
                    treeColumn.ColumnEdit = RepositoryItemEditor.MemoEdit(maxLength);
                    break;
                case DataType.MemoEx:
                    treeColumn.ColumnEdit = RepositoryItemEditor.MemoExEdit(maxLength, false);
                    break;
                case DataType.CheckEdit:
                    treeColumn.ColumnEdit = RepositoryItemEditor.CheckEdit();
                    break;
                case DataType.Date:
                    treeColumn.ColumnEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATEFORMAT);
                    break;
                case DataType.DateTime:
                    treeColumn.ColumnEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATETIMEFORMAT);
                    break;
                case DataType.Time:
                    treeColumn.ColumnEdit = RepositoryItemEditor.DateEdit("HH:mm:ss");
                    break;
                case DataType.TimeHM:
                    treeColumn.ColumnEdit = RepositoryItemEditor.DateEdit("HH:mm");
                    break;
                case DataType.TimeHMMS:
                    treeColumn.ColumnEdit = RepositoryItemEditor.DateEdit("HH:mm:ss.fff");
                    break;
                case DataType.Number:
                    treeColumn.ColumnEdit = RepositoryItemEditor.SpinEdit(decimalPlace, maxLength);
                    break;
                case DataType.Currency:
                    treeColumn.ColumnEdit = RepositoryItemEditor.CurrencyEdit(decimalPlace, maxLength);
                    break;
                case DataType.Percentage:
                    treeColumn.ColumnEdit = RepositoryItemEditor.PercentEdit(decimalPlace, maxLength);
                    break;
                case DataType.LinkButton:
                    treeColumn.ColumnEdit = RepositoryItemEditor.HyperLinkEdit();
                    break;
                case DataType.ButtonEdit:
                    treeColumn.ColumnEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard);
                    break;
                case DataType.ColorSelect:
                    treeColumn.ColumnEdit = RepositoryItemEditor.ColorEdit();
                    break;
                case DataType.Image:
                    treeColumn.ColumnEdit = RepositoryItemEditor.ImageEdit();
                    break;
                case DataType.Picture:
                    treeColumn.ColumnEdit = RepositoryItemEditor.PictureEdit();
                    break;
                case DataType.Password:
                    treeColumn.ColumnEdit = RepositoryItemEditor.PasswordEdit(maxLength);
                    break;
                case DataType.Progress:
                    treeColumn.ColumnEdit = RepositoryItemEditor.ProgressEdit();
                    break;
                case DataType.MarqueeProgress:
                    treeColumn.ColumnEdit = RepositoryItemEditor.MarqueeProgressEdit();
                    break;
                default:
                    treeColumn.ColumnEdit = RepositoryItemEditor.TextEdit(maxLength);
                    break;
            }
        }

        /// <summary>
        /// Column의 DataType을 정의합니다.
        /// </summary>
        /// <param name="gridColumn">Grid Column</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        internal static void SetColumnType(GridColumn gridColumn, DataType dataType, int maxLength, int decimalPlace)
        {
            switch (dataType)
            {
                case DataType.Memo:
                    gridColumn.ColumnEdit = RepositoryItemEditor.MemoEdit(maxLength);
                    break;
                case DataType.MemoEx:
                    gridColumn.ColumnEdit = RepositoryItemEditor.MemoExEdit(maxLength, false);
                    break;
                case DataType.CheckEdit:
                    gridColumn.ColumnEdit = RepositoryItemEditor.CheckEdit();
                    break;
                case DataType.Date:
                    gridColumn.ColumnEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATEFORMAT);
                    break;
                case DataType.DateTime:
                    gridColumn.ColumnEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATETIMEFORMAT);
                    break;
                case DataType.Time:
                    gridColumn.ColumnEdit = RepositoryItemEditor.DateEdit("HH:mm:ss");
                    break;
                case DataType.TimeHM:
                    gridColumn.ColumnEdit = RepositoryItemEditor.DateEdit("HH:mm");
                    break;
                case DataType.TimeHMMS:
                    gridColumn.ColumnEdit = RepositoryItemEditor.DateEdit("HH:mm:ss.fff");
                    break;
                case DataType.Number:
                    gridColumn.ColumnEdit  = RepositoryItemEditor.SpinEdit(decimalPlace, maxLength);
                    break;
                case DataType.Currency:
                    gridColumn.ColumnEdit = RepositoryItemEditor.CurrencyEdit(decimalPlace, maxLength);
                    break;
                case DataType.Percentage:
                    gridColumn.ColumnEdit = RepositoryItemEditor.PercentEdit(decimalPlace, maxLength);
                    break;
                case DataType.Button:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.HideTextEditor);
                    break;
                case DataType.ButtonEdit:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard);
                    break;
                case DataType.Popup:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard);
                    break;
                case DataType.LinkButton:
                    gridColumn.ColumnEdit = RepositoryItemEditor.HyperLinkEdit();
                    break;
                case DataType.ColorSelect:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ColorEdit();
                    break;
                case DataType.Image:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ImageEdit();
                    break;
                case DataType.Picture:
                    gridColumn.ColumnEdit = RepositoryItemEditor.PictureEdit();
                    break;
                case DataType.Password:
                    gridColumn.ColumnEdit = RepositoryItemEditor.PasswordEdit(maxLength);
                    break;
                case DataType.Progress:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ProgressEdit();
                    break;
                case DataType.MarqueeProgress:
                    gridColumn.ColumnEdit = RepositoryItemEditor.MarqueeProgressEdit();
                    break;
                case DataType.Language:
                    gridColumn.ColumnEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard); ;
                    break;
                default:
                    gridColumn.ColumnEdit = RepositoryItemEditor.TextEdit(maxLength);
                    break;
            }
        }

        /// <summary>
        /// Column의 DataType을 정의합니다.
        /// </summary>
        /// <param name="gridField">Pivot Grid Column</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        internal static void SetColumnType(PivotGridField gridField, DataType dataType, int maxLength, int decimalPlace)
        {
            switch (dataType)
            {
                case DataType.Memo:
                    gridField.FieldEdit = RepositoryItemEditor.MemoEdit(maxLength);
                    break;
                case DataType.MemoEx:
                    gridField.FieldEdit = RepositoryItemEditor.MemoExEdit(maxLength, false);
                    break;
                case DataType.CheckEdit:
                    gridField.FieldEdit = RepositoryItemEditor.CheckEdit();
                    break;
                case DataType.Date:
                    gridField.FieldEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATEFORMAT);
                    break;
                case DataType.DateTime:
                    gridField.FieldEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATETIMEFORMAT);
                    break;
                case DataType.Time:
                    gridField.FieldEdit = RepositoryItemEditor.DateEdit("HH:mm:ss");
                    break;
                case DataType.TimeHM:
                    gridField.FieldEdit = RepositoryItemEditor.DateEdit("HH:mm");
                    break;
                case DataType.TimeHMMS:
                    gridField.FieldEdit = RepositoryItemEditor.DateEdit("HH:mm:ss.fff");
                    break;
                case DataType.Number:
                    gridField.FieldEdit = RepositoryItemEditor.SpinEdit(decimalPlace, maxLength);
                    gridField.CellFormat.FormatString = "{0:n" + decimalPlace.ToString() + "}";
                    break;
                case DataType.Currency:
                    gridField.FieldEdit = RepositoryItemEditor.CurrencyEdit(decimalPlace, maxLength);
                    break;
                case DataType.Percentage:
                    gridField.FieldEdit = RepositoryItemEditor.PercentEdit(decimalPlace, maxLength);
                    break;
                case DataType.Button:
                    gridField.FieldEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.HideTextEditor);
                    break;
                case DataType.ButtonEdit:
                    gridField.FieldEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard);
                    break;
                case DataType.Popup:
                    gridField.FieldEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard);
                    break;
                case DataType.LinkButton:
                    gridField.FieldEdit = RepositoryItemEditor.HyperLinkEdit();
                    break;
                case DataType.ColorSelect:
                    gridField.FieldEdit = RepositoryItemEditor.ColorEdit();
                    break;
                case DataType.Image:
                    gridField.FieldEdit = RepositoryItemEditor.ImageEdit();
                    break;
                case DataType.Picture:
                    gridField.FieldEdit = RepositoryItemEditor.PictureEdit();
                    break;
                case DataType.Password:
                    gridField.FieldEdit = RepositoryItemEditor.PasswordEdit(maxLength);
                    break;
                case DataType.Progress:
                    gridField.FieldEdit = RepositoryItemEditor.ProgressEdit();
                    break;
                case DataType.MarqueeProgress:
                    gridField.FieldEdit = RepositoryItemEditor.MarqueeProgressEdit();
                    break;
                case DataType.Language:
                    gridField.FieldEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard); ;
                    break;
                default:
                    gridField.FieldEdit = RepositoryItemEditor.TextEdit(maxLength);
                    break;
            }
        }

        /// <summary>
        /// Row의 DataType을 정의합니다.
        /// </summary>
        /// <param name="gridRow">Grid Column</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        internal static void SetRowType(BaseRow gridRow, DataType dataType, int decimalPlace)
        {
            switch (dataType)
            {
                case DataType.Memo:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.MemoExEdit(0, false);
                    break;
                case DataType.MemoEx:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.MemoExEdit(0, true);
                    break;
                case DataType.CheckEdit:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.CheckEdit();
                    break;
                case DataType.Date:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATEFORMAT);
                    break;
                case DataType.DateTime:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.DateEdit(AppConfig.DEFAULTDATETIMEFORMAT);
                    break;
                case DataType.Time:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.DateEdit("HH:mm:ss");
                    break;
                case DataType.TimeHM:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.DateEdit("HH:mm");
                    break;
                case DataType.TimeHMMS:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.DateEdit("HH:mm:ss.fff");
                    break;
                case DataType.Number:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.SpinEdit(decimalPlace, 0);
                    break;
                case DataType.Currency:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.CurrencyEdit(decimalPlace, 0);
                    break;
                case DataType.Percentage:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.PercentEdit(decimalPlace, 0);
                    break;
                case DataType.Button:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.HideTextEditor);
                    break;
                case DataType.ButtonEdit:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.ButtonEdit(TextEditStyles.Standard);
                    break;
                case DataType.LinkButton:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.HyperLinkEdit();
                    break;
                case DataType.ColorSelect:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.ColorEdit();
                    break;
                case DataType.Image:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.ImageEdit();
                    break;
                case DataType.Picture:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.PictureEdit();
                    break;
                case DataType.Password:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.PasswordEdit(0);
                    break;
                case DataType.Progress:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.ProgressEdit();
                    break;
                case DataType.MarqueeProgress:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.MarqueeProgressEdit();
                    break;
                default:
                    gridRow.Properties.RowEdit = RepositoryItemEditor.TextEdit(0);
                    break;
            }
        }

        #endregion
    }
}
