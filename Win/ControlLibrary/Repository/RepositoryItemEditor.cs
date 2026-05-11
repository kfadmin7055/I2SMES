using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using EBAP.Core.Info;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace EBAP.Win.ControlLibrary.Repository
{
    internal class RepositoryItemEditor
    {
        internal static RepositoryItemTextEdit TextEdit(int maxLength)
        {
            var edit = new RepositoryItemTextEdit { MaxLength = maxLength };

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            
            return edit;
        }

        internal static RepositoryItemCheckEdit CheckEdit()
        {
            var edit = new RepositoryItemCheckEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullStyle = StyleIndeterminate.Unchecked;

            if (clsDBHelper.GetDBType(AppConfig.CurrentDB) == DB_TYPE.ORACLE)
            {
                edit.ValueChecked = "1";
                edit.ValueUnchecked = "0";
            }
            else
            {
                edit.ValueChecked = true;
                edit.ValueUnchecked = false;
            }

            return edit;
        }

        internal static RepositoryItemColorEdit ColorEdit()
        {
            var edit = new RepositoryItemColorEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;

            return edit;
        }

        internal static RepositoryItemButtonEdit ButtonEdit(TextEditStyles style)
        {
            var button = new PRepositoryItemButtonEdit() { TextEditStyle = style };

            switch (style)
            {
                case TextEditStyles.HideTextEditor:
                case TextEditStyles.DisableTextEditor:
                    button.Buttons[0].Kind = ButtonPredefines.Separator;
                    button.BorderStyle = BorderStyles.Simple;
                    break;
                default:
                    button.Buttons[0].Kind = ButtonPredefines.Search;
                    break;
            }

            //button.Appearance.Font = ControlConfig.DEFAULTFONT;

            return button;
        }

        internal static RepositoryItemTextEdit HyperLinkEdit()
        {
            var edit = new RepositoryItemHyperLinkEdit();
            //var edit = new RepositoryItemTextEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.Appearance.ForeColor = DXSkinColors.FillColors.Primary;// System.Drawing.Color.FromArgb(230, 20, 110, 190);
            //edit.Appearance.ForeColor = System.Drawing.Color.FromArgb(230, 90, 140, 125);  //그린 계열
            edit.TextEditStyle = TextEditStyles.Standard;

            return edit;
        }

        internal static RepositoryItemSpinEdit SpinEdit(int decimalPlace, int maxLength)
        {
            var edit = new RepositoryItemSpinEdit();

            edit.Buttons.Clear();

            edit.DisplayFormat.FormatType = FormatType.Numeric;
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.Mask.MaskType = MaskType.Numeric;

            edit.DisplayFormat.FormatString = "n" + decimalPlace;
            edit.Mask.EditMask = "n" + decimalPlace;
            edit.Mask.UseMaskAsDisplayFormat = true;

            if (maxLength != 0) edit.MaxLength = maxLength;

            return edit;
        }

        internal static RepositoryItemTextEdit PercentEdit(int decimalPlace, int maxLength)
        {
            var edit = new RepositoryItemTextEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.DisplayFormat.FormatType = FormatType.Numeric;
            edit.DisplayFormat.FormatString = "p" + decimalPlace;
            edit.Mask.EditMask = "p" + decimalPlace;
            edit.Mask.MaskType = MaskType.Numeric;
            edit.Mask.UseMaskAsDisplayFormat = true;

            if (maxLength != 0) edit.MaxLength = maxLength;

            return edit;
        }

        internal static RepositoryItemTextEdit CurrencyEdit(int decimalPlace, int maxLength)
        {
            var edit = new RepositoryItemTextEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.DisplayFormat.FormatType = FormatType.Numeric;
            edit.DisplayFormat.FormatString = "c" + decimalPlace;
            edit.Mask.EditMask = "c" + decimalPlace;
            edit.Mask.MaskType = MaskType.Numeric;
            edit.Mask.UseMaskAsDisplayFormat = true;

            if (maxLength != 0) edit.MaxLength = maxLength;

            return edit;
        }

        internal static RepositoryItemDateEdit DateEdit(string editMask)
        {
            var edit = new RepositoryItemDateEdit { HighlightHolidays = true };

            edit.Appearance.Font = ControlConfig.DROPDOWNFONT;
            edit.AppearanceDropDown.Font = ControlConfig.DROPDOWNFONT;
            edit.AppearanceDropDownHeader.Font = ControlConfig.DROPDOWNFONT;
            edit.AppearanceWeekNumber.Font = ControlConfig.DROPDOWNFONT;
            edit.NullDate = string.Empty;
            edit.Mask.EditMask = editMask;
            //edit.Mask.MaskType = MaskType.DateTime;
            edit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            edit.Mask.UseMaskAsDisplayFormat = true;

            return edit;
        }

        internal static RepositoryItemImageEdit ImageEdit()
        {
            var edit = new RepositoryItemImageEdit { SizeMode = PictureSizeMode.Stretch, PictureStoreMode = PictureStoreMode.ByteArray };
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;

            return edit;
        }

        internal static RepositoryItemMemoEdit MemoEdit(int maxLength)
        {
            var edit = new PRepositoryItemMemoEdit { MaxLength = maxLength };
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;

            return edit;
        }

        internal static RepositoryItemMemoExEdit MemoExEdit(int maxLength, bool showIcon)
        {
            var edit = new PRepositoryItemMemoExEdit { MaxLength = maxLength, ShowIcon = showIcon };
            edit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            edit.Appearance.Font = ControlConfig.DROPDOWNFONT;

            return edit;
        }

        internal static RepositoryItemTextEdit PasswordEdit(int maxLength)
        {
            var edit = new RepositoryItemTextEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.PasswordChar = '*';
            edit.MaxLength = maxLength;

            return edit;
        }

        internal static RepositoryItemTextEdit TimeEdit(string editMask)
        {
            var edit = new RepositoryItemTimeEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.Mask.EditMask = editMask;
            //edit.Mask.UseMaskAsDisplayFormat = true;
            //edit.Mask.MaskType = MaskType.Custom;
            edit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;

            return edit;
        }

        internal static RepositoryItemPictureEdit PictureEdit()
        {
            var edit = new RepositoryItemPictureEdit { SizeMode = PictureSizeMode.Stretch, PictureStoreMode = PictureStoreMode.ByteArray };
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;

            return edit;
        }

        internal static RepositoryItemProgressBar ProgressEdit()
        {
            var edit = new RepositoryItemProgressBar();
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            edit.ShowTitle = true;
            edit.PercentView = true;

            return edit;
        }

        internal static RepositoryItemMarqueeProgressBar MarqueeProgressEdit()
        {
            var edit = new RepositoryItemMarqueeProgressBar();
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            edit.ShowTitle = true;

            return edit;
        }

        internal static RepositoryItemRadioGroup RadioGroupEdit(DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            RepositoryItemRadioGroup edit = new RepositoryItemRadioGroup();

            DataRow dr;

            if (selectAllItemVisible)
            {
                dr = dt.NewRow();

                if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
                    dr[valueMember] = "";
                else
                    dr[valueMember] = -1;

                dr[displayMember] = "전체";
                dt.Rows.InsertAt(dr, 0);
            }

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullText = "";

            foreach (DataRow drs in dt.Rows)
            {
                RadioGroupItem rgi = new RadioGroupItem { Value = drs[valueMember], Description = drs[displayMember].ToString() };
                edit.Items.Add(rgi);
            }

            return edit;
        }

        internal static RepositoryItemLookUpEdit ComboBoxEdit(DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            DataRow dr;
            if (selectAllItemVisible)
            {
                dr = dt.NewRow();

                if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
                    dr[valueMember] = "";
                else
                    dr[valueMember] = -1;

                dr[displayMember] = "전체";
                dt.Rows.InsertAt(dr, 0);
            }

            edit.Appearance.Font = ControlConfig.DROPDOWNFONT;
            edit.AppearanceDropDown.Font = ControlConfig.DROPDOWNFONT;
            edit.AppearanceDropDownHeader.Font = ControlConfig.DROPDOWNFONT;
            edit.NullText = "";
            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            //string[] columns = dt.GetColumnsFromDataTable();
            //Array.ForEach(columns, column =>
            //{
            //    edit.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, HorzAlignment.Center, showCodeColumnVisible) : CreateColumn(column, column, 120, HorzAlignment.Default, true));
            //});

            edit.Columns.Add(ControlUtil.CreateLookUpColumn(valueMember, valueMember, 70, HorzAlignment.Center, showCodeColumn));
            edit.Columns.Add(ControlUtil.CreateLookUpColumn(displayMember, displayMember, 120, HorzAlignment.Default, true));

            edit.ShowHeader = false;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            return edit;
        }

        internal static RepositoryItemCheckedComboBoxEdit CheckedComboBoxEdit(DataTable dt, bool selectAllItemVisible, string valueMember, string displayMember)
        {
            RepositoryItemCheckedComboBoxEdit edit = new RepositoryItemCheckedComboBoxEdit { SelectAllItemCaption = "전체", SelectAllItemVisible = selectAllItemVisible };

            edit.Appearance.Font = ControlConfig.DROPDOWNFONT;
            edit.AppearanceDropDown.Font = ControlConfig.DROPDOWNFONT;
            edit.NullText = "";

            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            return edit;
        }
    }
}
