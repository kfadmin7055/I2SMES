using EBAP.Core.Info;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// Vertical GridControl Row Initialize 기능을 정의하는 Interface입니다.
    /// </summary>
    public interface IInitVerticalRow
    {
        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        void InitRow(string fieldName, string caption);

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        void InitRow(string fieldName, string caption, int width);

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible"></param>
        void InitRow(string fieldName, string caption, int width, bool allowEdit, bool visible);

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible"></param>
        /// <param name="dataType"></param>
        void InitRow(string fieldName, string caption, int width, bool allowEdit, bool visible, DataType dataType);

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible"></param>
        /// <param name="dataType"></param>
        /// <param name="horzAlign"></param>
        void InitRow(string fieldName, string caption, int width, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign);

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="decimalPlace"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible"></param>
        /// <param name="dataType"></param>
        /// <param name="horzAlign"></param>
        void InitRow(string fieldName, string caption, int width, int decimalPlace, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign);

        /// <summary>
        /// Vertical GridControl MultiEditor Row 를 초기화합니다.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fieldnames">Multi Editor Row Name</param>
        /// <param name="captions">Captions</param>
        void InitMultiEditorRow(string name, string[] fieldnames, string[] captions);

        /// <summary>
        /// Vertical GridControl Category Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Caption</param>
        void InitCategoryRow(string fieldName, string caption);
    }
}
