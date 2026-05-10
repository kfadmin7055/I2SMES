using DevExpress.XtraScheduler.Localization;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Schedule Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PSchedulerLocalizer : DevExpress.XtraScheduler.Localization.SchedulerLocalizer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(SchedulerStringId id)
        {
            switch (id)
            {
                case SchedulerStringId.Abbr_Day: return " 일";
                case SchedulerStringId.Abbr_Days: return " 일";
                case SchedulerStringId.Abbr_DaysShort: return " d";
                case SchedulerStringId.Abbr_Hour: return " 시간";
                case SchedulerStringId.Abbr_Hours: return " 시간";
                case SchedulerStringId.Abbr_HoursShort: return " h";
                case SchedulerStringId.Abbr_Minute: return " 분";
                case SchedulerStringId.Abbr_Minutes: return " 분";
                case SchedulerStringId.Abbr_MinutesShort1: return " m";
                case SchedulerStringId.Abbr_MinutesShort2: return " 분";
                case SchedulerStringId.Abbr_Month: return " 개월";
                case SchedulerStringId.Abbr_Months: return " 개월";
                case SchedulerStringId.Abbr_Week: return " 주";
                case SchedulerStringId.Abbr_Weeks: return " 주";
                case SchedulerStringId.Abbr_WeeksShort: return " w";
                case SchedulerStringId.Abbr_Year: return " 년";
                case SchedulerStringId.Abbr_Years: return " 년";
                case SchedulerStringId.Appointment_EndContinueText: return " {0}까지";
                case SchedulerStringId.AppointmentLabel_Anniversary: return " 기념일";
                case SchedulerStringId.AppointmentLabel_Birthday: return " 생일";
                case SchedulerStringId.AppointmentLabel_Business: return " 업무적인";
                case SchedulerStringId.AppointmentLabel_Important: return " 중요";
                case SchedulerStringId.AppointmentLabel_MustAttend: return " 참여 필수";
                case SchedulerStringId.AppointmentLabel_NeedsPreparation: return " 준비 필요";
                case SchedulerStringId.AppointmentLabel_None: return " 없음";
                case SchedulerStringId.AppointmentLabel_Personal: return " 개인적인";
                case SchedulerStringId.AppointmentLabel_PhoneCall: return " 전화";
                case SchedulerStringId.AppointmentLabel_TravelRequired: return " 출장";
                case SchedulerStringId.AppointmentLabel_Vacation: return " 휴가";
                case SchedulerStringId.Caption_10Minutes: return " 10분";
                case SchedulerStringId.Caption_15Minutes: return " 15분";
                case SchedulerStringId.Caption_20Minutes: return " 30분";
                case SchedulerStringId.Caption_30Minutes: return " 30분";
                case SchedulerStringId.Caption_5Minutes: return " 5분";
                case SchedulerStringId.Caption_60Minutes: return " 60분";
                case SchedulerStringId.Caption_6Minutes: return " 6분";
                case SchedulerStringId.Caption_AllDay: return " 하루 종일";
                case SchedulerStringId.Caption_AllResources: return " 모든 자원";
                case SchedulerStringId.Caption_Appointment: return " {0}-약속";
                case SchedulerStringId.Caption_AppointmentDependencyTypeFinishToFinish: return " 완료-완료 (FF)";
                case SchedulerStringId.Caption_AppointmentDependencyTypeFinishToStart: return " 마침 위해 시작 (FS)";
                case SchedulerStringId.Caption_AppointmentDependencyTypeStartToFinish: return " 시작에 완료 (SF)";
                case SchedulerStringId.Caption_Busy: return " 약속 있음";
                case SchedulerStringId.Caption_CalendarDetailsPrintStyle: return " 일정 세부 스타일";
                case SchedulerStringId.Caption_ColorConverterBlackAndWhite: return " 흑백";
                case SchedulerStringId.Caption_ColorConverterFullColor: return " 풀 컬러";
                case SchedulerStringId.Caption_ColorConverterGrayScale: return " 그레이 스케일";
                case SchedulerStringId.Caption_DailyPrintStyle: return " 매일 스타일";
                case SchedulerStringId.Caption_DayViewDescription: return " 스위치입니다. 특정 일에 대 한 약속의 가장 상세한 보기.";
                case SchedulerStringId.Caption_DecreaseVisibleResourcesCount: return " 표시 리소스 수 감소";
                case SchedulerStringId.Caption_EmptyResource: return " (모든)";
                case SchedulerStringId.Caption_Event: return " {0}-이벤트";
                case SchedulerStringId.Caption_FirstVisibleResources: return " 첫 번째";
                case SchedulerStringId.Caption_Free: return " 약속 없음";
                case SchedulerStringId.Caption_FullWeekViewDescription: return " 전체 주 보기로 전환 합니다. 컴팩트한 형태로 특정 주에 대 한 약속을 배열 한다.";
                case SchedulerStringId.Caption_GroupByDate: return " 날짜";
                case SchedulerStringId.Caption_GroupByDateDescription: return " 날짜 약속을 그룹화 합니다.";
                case SchedulerStringId.Caption_GroupByNone: return " 없음";
                case SchedulerStringId.Caption_GroupByResources: return " 리소스";
                case SchedulerStringId.Caption_IncreaseVisibleResourcesCount: return " 표시 리소스 개수 증가";
                case SchedulerStringId.Caption_LastVisibleResources: return " 마지막";
                case SchedulerStringId.Caption_MappingsValidation: return " 매핑 유효성 검사";
                case SchedulerStringId.Caption_MappingsWizard: return " 매핑 마법사...";
                case SchedulerStringId.Caption_MemoPrintStyle: return " 메모 스타일";
                case SchedulerStringId.Caption_ModifyAppointmentDependencyMappingsTransactionDescription: return " 약속 종속성 매핑 수정";
                case SchedulerStringId.Caption_ModifyAppointmentMappingsTransactionDescription: return " 일정 매핑 수정";
                case SchedulerStringId.Caption_ModifyAppointmentStorageTransactionDescription: return " 일정 저장 수정";
                case SchedulerStringId.Caption_MonthlyPrintStyle: return " 매월 스타일";
                case SchedulerStringId.Caption_NextAppointment: return " 다음 약속";
                case SchedulerStringId.Caption_NextVisibleResources: return " 다음";
                case SchedulerStringId.Caption_NextVisibleResourcesPage: return " 다음 페이지";
                case SchedulerStringId.Caption_NoneRecurrence: return " (없음)";
                case SchedulerStringId.Caption_NoneReminder: return " 없음";
                case SchedulerStringId.Caption_OnScreenResources: return " OnScreen 리소스";
                case SchedulerStringId.Caption_OutOfOffice: return " 부재 중";
                case SchedulerStringId.Caption_PleaseSeeAbove: return " 위 참조";
                case SchedulerStringId.Caption_PrevAppointment: return " 이전 약속";
                case SchedulerStringId.Caption_PrevVisibleResources: return " 이전";
                case SchedulerStringId.Caption_PrevVisibleResourcesPage: return " 이전 페이지";
                case SchedulerStringId.Caption_ReadOnly: return " [읽기 전용]";
                case SchedulerStringId.Caption_RecurrenceEndTime: return " 끝:";
                case SchedulerStringId.Caption_RecurrenceLocation: return " 위치:";
                case SchedulerStringId.Caption_RecurrenceShowTimeAs: return " 시간 표시 형식:";
                case SchedulerStringId.Caption_RecurrenceStartTime: return " 시작:";
                case SchedulerStringId.Caption_RecurrenceSubject: return " 제목:";
                case SchedulerStringId.Caption_Reminder: return " {0}개 항목 미리 알림";
                case SchedulerStringId.Caption_Reminders: return " {0}개 항목 미리 알림";
                case SchedulerStringId.Caption_ResourceAll: return " (모두)";
                case SchedulerStringId.Caption_ResourceNone: return " (없음)";
                case SchedulerStringId.Caption_SetupAppointmentDependencyStorage: return " 종속성 저장소 설정";
                case SchedulerStringId.Caption_SetupAppointmentMappings: return " 약속 매핑 설정";
                case SchedulerStringId.Caption_SetupAppointmentStorage: return " 약속 저장소 설정";
                case SchedulerStringId.Caption_SetupDependencyMappings: return " 종속성 매핑 설정";
                case SchedulerStringId.Caption_SetupResourceMappings: return " 리소스 매핑 설정";
                case SchedulerStringId.Caption_SetupResourceStorage: return " 리소스 저장소 설정";
                case SchedulerStringId.Caption_ShadingApplyToAllDayArea: return " 하루 종일 영역";
                case SchedulerStringId.Caption_ShadingApplyToAppointments: return " 약속";
                case SchedulerStringId.Caption_ShadingApplyToAppointmentStatuses: return " 약속 상태";
                case SchedulerStringId.Caption_ShadingApplyToCells: return " 셀";
                case SchedulerStringId.Caption_ShadingApplyToHeaders: return " 헤더";
                case SchedulerStringId.Caption_ShadingApplyToTimeRulers: return " 시간 눈금자";
                case SchedulerStringId.Caption_SplitAppointment: return " 분할";
                case SchedulerStringId.Caption_StartTime: return " 시작 시간: {0}";
                case SchedulerStringId.Caption_Tentative: return " 미정";
                case SchedulerStringId.Caption_TrifoldPrintStyle: return " 3 폴더 형 스타일";
                case SchedulerStringId.Caption_UntitledAppointment: return " 제목없음";
                case SchedulerStringId.Caption_VisibleResources: return " 표시 리소스";
                case SchedulerStringId.Caption_WeekDaysEveryDay: return " 매일";
                case SchedulerStringId.Caption_WeekDaysWeekendDays: return " 주말";
                case SchedulerStringId.Caption_WeekDaysWorkDays: return " 평일";
                case SchedulerStringId.Caption_WeeklyPrintStyle: return " 주간 스타일";
                case SchedulerStringId.Caption_WeekOfMonthFirst: return " 첫째";
                case SchedulerStringId.Caption_WeekOfMonthFourth: return " 넷째";
                case SchedulerStringId.Caption_WeekOfMonthLast: return " 마지막";
                case SchedulerStringId.Caption_WeekOfMonthSecond: return " 둘째";
                case SchedulerStringId.Caption_WeekOfMonthThird: return " 셋째";
                case SchedulerStringId.Caption_WorkingElsewhere: return " 다른 곳에서 작업";
                case SchedulerStringId.CategoryResourceSelectorCaption_Cancel: return " 취소";
                case SchedulerStringId.CategoryResourceSelectorCaption_Ok: return " 확인";
                case SchedulerStringId.DateNavigationBarCaption_Today: return " 오늘";
                case SchedulerStringId.DateTimeAutoFormat_Week: return " ";
                case SchedulerStringId.DateTimeAutoFormat_WithoutYear: return " ";
                case SchedulerStringId.DefaultToolTipStringFormat_SplitAppointment: return " {0}: {1} 단계";
                case SchedulerStringId.DescCmd_ChangeAppointmentReminderUI: return " 선택된 약속 미리 알림 전송 시간을 선택할 수 있습니다.";
                case SchedulerStringId.DescCmd_ChangeSnapToCellsUI: return " 시간 세포 내 약속을 표시 하기 위한 맞춤 모드를 지정 합니다.";
                case SchedulerStringId.DescCmd_ChangeTimelineScaleWidth: return " 기본 스케일의 열 폭을 픽셀로 지정합니다.";
                case SchedulerStringId.DescCmd_CreateAppointmentDependency: return " 약속 사이의 의존 관계 만들기";
                case SchedulerStringId.DescCmd_DeleteAppointment: return " 선택한 약속을 삭제합니다.";
                case SchedulerStringId.DescCmd_DeleteAppointmentDependency: return " 약속 종속성을 삭제 합니다.";
                case SchedulerStringId.DescCmd_DeleteOccurrence: return " 약속을 삭제 합니다.";
                case SchedulerStringId.DescCmd_DeleteSeries: return " 시리즈를 삭제 합니다.";
                case SchedulerStringId.DescCmd_EditAppointmentDependency: return " 약속 종속성을 편집 합니다.";
                case SchedulerStringId.DescCmd_LabelAs: return " 선택한 약속 레이블을 변경 합니다.";
                case SchedulerStringId.DescCmd_NavigateForward: return " 현재 보기에 의해 제안 된 시간에 앞으로 전진 합니다.";
                case SchedulerStringId.DescCmd_NewAppointment: return " 새 약속을 만듭니다.";
                case SchedulerStringId.DescCmd_NewRecurringAppointment: return " 새 되풀이 약속을 만듭니다.";
                case SchedulerStringId.DescCmd_OpenAppointment: return " 선택한 약속을 엽니다.";
                case SchedulerStringId.DescCmd_OpenOccurrence: return " 이 모임의 일정을 엽니다.";
                case SchedulerStringId.DescCmd_OpenSchedule: return " 일정 파일 (.ics)에서 가져옵니다.";
                case SchedulerStringId.DescCmd_Print: return " 변경 하지 않고 기본 프린터에 직접 일정을 보낼 합니다.";
                case SchedulerStringId.DescCmd_PrintPageSetup: return " 페이지 모양을 사용자 정의하고 인쇄 옵션을 설정합니다.";
                case SchedulerStringId.DescCmd_PrintPreview: return " 인쇄 하기 전에 페이지의 변경 내용을 미리 보기 하 고 확인 합니다.";
                case SchedulerStringId.DescCmd_SaveSchedule: return " 일정 파일 (.ics)에 저장 합니다.";
                case SchedulerStringId.DescCmd_ShowTimeAs: return " 선택한 일정 상태를 변경 합니다.";
                case SchedulerStringId.DescCmd_ShowWorkTimeOnly: return " 달력에서 작업 시간을 표시 합니다.";
                case SchedulerStringId.DescCmd_SplitAppointment: return " 두 분할 선을 드래그 하 여 선택한 약속을 분할 합니다.";
                case SchedulerStringId.DescCmd_ToggleRecurrence: return " 선택한 약속 되풀이 또는 되풀이 편집.";
                case SchedulerStringId.DescCmd_ViewZoomIn: return " 수행 내용을 자세히 표시 하도록 확장.";
                case SchedulerStringId.DescCmd_ViewZoomOut: return " 수행 보기의 광범위 한 보기를 표시 하려면 축소 합니다.";
                case SchedulerStringId.DisplayName_Appointment: return " 약속";
                case SchedulerStringId.FlyoutCaption_Location: return " 위치:";
                case SchedulerStringId.FlyoutCaption_Reminder: return " 알림:";
                case SchedulerStringId.FlyoutCaption_Start: return " 시작:";
                case SchedulerStringId.Format_CopyNOf: return " {1}의 복사본 ({0})";
                case SchedulerStringId.Format_CopyOf: return " {0} 복사";
                case SchedulerStringId.Format_TimeBeforeStart: return " 시작 {0}전";
                case SchedulerStringId.MemoPrintDateFormat: return " {0} {1} {2}";
                case SchedulerStringId.MenuCmd_10Minutes: return " 10분";
                case SchedulerStringId.MenuCmd_15Minutes: return " 15분";
                case SchedulerStringId.MenuCmd_20Minutes: return " 20분";
                case SchedulerStringId.MenuCmd_30Minutes: return " 30분";
                case SchedulerStringId.MenuCmd_5Minutes: return " 5분";
                case SchedulerStringId.MenuCmd_60Minutes: return " 60분";
                case SchedulerStringId.MenuCmd_6Minutes: return " 6분";
                case SchedulerStringId.MenuCmd_AppointmentCancel: return " 취소(&C)";
                case SchedulerStringId.MenuCmd_AppointmentCopy: return " 복사(&C)";
                case SchedulerStringId.MenuCmd_AppointmentLabelAnniversary: return " 기념일";
                case SchedulerStringId.MenuCmd_AppointmentLabelBirthday: return " 생일";
                case SchedulerStringId.MenuCmd_AppointmentLabelBusiness: return " 업무적인";
                case SchedulerStringId.MenuCmd_AppointmentLabelImportant: return " 중요";
                case SchedulerStringId.MenuCmd_AppointmentLabelMustAttend: return " 참여 필수";
                case SchedulerStringId.MenuCmd_AppointmentLabelNeedsPreparation: return " 준비 필요";
                case SchedulerStringId.MenuCmd_AppointmentLabelNone: return " 없음";
                case SchedulerStringId.MenuCmd_AppointmentLabelPersonal: return " 개인적인(&P)";
                case SchedulerStringId.MenuCmd_AppointmentLabelPhoneCall: return " 전화";
                case SchedulerStringId.MenuCmd_AppointmentLabelTravelRequired: return " 출장";
                case SchedulerStringId.MenuCmd_AppointmentLabelVacation: return " 휴가";
                case SchedulerStringId.MenuCmd_Busy: return " 약속 있음(&B)";
                case SchedulerStringId.MenuCmd_CellsAutoHeight: return " 셀 높이 자동 조정";
                case SchedulerStringId.MenuCmd_ChangeAppointmentReminderUI: return " 알림";
                case SchedulerStringId.MenuCmd_ChangeSnapToCellsUI: return " 셀에 스냅";
                case SchedulerStringId.MenuCmd_ChangeTimelineScaleWidth: return " 스케일 폭";
                case SchedulerStringId.MenuCmd_CompressWeekend: return " 주말 압축";
                case SchedulerStringId.MenuCmd_CreateAppointmentDependency: return " 종속성 만들기";
                case SchedulerStringId.MenuCmd_CustomizeTimeRuler: return " 사용자 지정 시간 눈금자...";
                case SchedulerStringId.MenuCmd_DeleteAppointment: return " &삭제";
                case SchedulerStringId.MenuCmd_DeleteAppointmentDependency: return " 삭제(&D)";
                case SchedulerStringId.MenuCmd_DeleteOccurrence: return " 항목 삭제";
                case SchedulerStringId.MenuCmd_DeleteSeries: return " 시리즈 삭제";
                case SchedulerStringId.MenuCmd_Free: return " 약속 없음(&F)";
                case SchedulerStringId.MenuCmd_GotoDate: return " 날짜 이동(&G)";
                case SchedulerStringId.MenuCmd_GotoThisDay: return " 세부 일정(&D)";
                case SchedulerStringId.MenuCmd_GotoToday: return " 오늘(&T)";
                case SchedulerStringId.MenuCmd_LabelAs: return " &범주";
                case SchedulerStringId.MenuCmd_NavigateBackward: return " 이전";
                case SchedulerStringId.MenuCmd_NavigateForward: return " 다음";
                case SchedulerStringId.MenuCmd_NewAllDayEvent: return " 새 행사(&E)";
                case SchedulerStringId.MenuCmd_NewAppointment: return " 새 약속(&O)";
                case SchedulerStringId.MenuCmd_NewRecurringAppointment: return " 새 되풀이 약속(&A)";
                case SchedulerStringId.MenuCmd_NewRecurringEvent: return " 새 되풀이 행사(&V)";
                case SchedulerStringId.MenuCmd_OpenAppointment: return " &약속 열기";
                case SchedulerStringId.MenuCmd_OpenOccurrence: return " 약속 열기";
                case SchedulerStringId.MenuCmd_OpenSchedule: return " 열기";
                case SchedulerStringId.MenuCmd_OpenSeries: return " 시리즈 열기";
                case SchedulerStringId.MenuCmd_OtherSettings: return " 다른 설정(&i)...";
                case SchedulerStringId.MenuCmd_OutOfOffice: return " 부재 중(&O)";
                case SchedulerStringId.MenuCmd_Print: return " 빠른 인쇄";
                case SchedulerStringId.MenuCmd_PrintAppointment: return " 인쇄(&P)";
                case SchedulerStringId.MenuCmd_PrintPageSetup: return " 페이지 설정(&S)";
                case SchedulerStringId.MenuCmd_PrintPreview: return " 인쇄 미리보기(&P)";
                case SchedulerStringId.MenuCmd_SaveSchedule: return " 저장";
                case SchedulerStringId.MenuCmd_ShowTimeAs: return " &표시";
                case SchedulerStringId.MenuCmd_ShowWorkTimeOnly: return " 근무 시간";
                case SchedulerStringId.MenuCmd_SwitchToDayView: return " 하루(&D)";
                case SchedulerStringId.MenuCmd_SwitchToGanttView: return " 간트 뷰(&G)";
                case SchedulerStringId.MenuCmd_SwitchToMonthView: return " 월(&M)";
                case SchedulerStringId.MenuCmd_SwitchToTimelineView: return " 일정 보기(&T)";
                case SchedulerStringId.MenuCmd_SwitchToWeekView: return " 주(&W)";
                case SchedulerStringId.MenuCmd_SwitchToWorkWeekView: return " 작업주(&R)";
                case SchedulerStringId.MenuCmd_SwitchViewMenu: return " 보기 설정";
                case SchedulerStringId.MenuCmd_Tentative: return " 미정(&T)";
                case SchedulerStringId.MenuCmd_TimeScaleDay: return " 일(&D)";
                case SchedulerStringId.MenuCmd_TimeScaleHour: return " 시간(&H)";
                case SchedulerStringId.MenuCmd_TimeScaleQuarter: return " 분기(&Q)";
                case SchedulerStringId.MenuCmd_TimeScaleWeek: return " 주(&W)";
                case SchedulerStringId.MenuCmd_TimeScaleWorkDay: return " 근무일";
                case SchedulerStringId.MenuCmd_TimeScaleWorkHour: return " 근무 시간";
                case SchedulerStringId.MenuCmd_TimeScaleYear: return " 년(&Y)";
                case SchedulerStringId.MenuCmd_ToggleRecurrence: return " 되풀이";
                case SchedulerStringId.MenuCmd_ViewZoomIn: return " 확대";
                case SchedulerStringId.MenuCmd_ViewZoomOut: return " 축소";
                case SchedulerStringId.Msg_ApplyToAllStyles: return " 모든 스타일에 현재의 인쇄 설정을 반영 하시겠습니까?";
                case SchedulerStringId.Msg_DuplicateCustomFieldMappings: return " 중복 사용자 정의 필드 이름입니다. 매핑을 수정: {0}";
                case SchedulerStringId.Msg_iCalendar_AppointmentsImportWarning: return " 일부 약속을 가져올 수 없습니다.";
                case SchedulerStringId.Msg_iCalendar_NotValidFile: return " 잘못된 인터넷 캘린더 파일";
                case SchedulerStringId.Msg_InternalError: return " 내부 오류!";
                case SchedulerStringId.Msg_InvalidDayCount: return " 잘못 된 날 수입니다. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidDayCountValue: return " 잘못 된 날 수입니다. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidDayNumber: return " 잘못 된 날 수입니다. 1에서 {0}에 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidDayNumberValue: return " 잘못 된 날 수입니다. 1에서 {0}에 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidEndDate: return " 입력 한 날짜는 시작 날짜 전에 발생 합니다.";
                case SchedulerStringId.Msg_InvalidInputFile: return " 입력 파일이 잘못되었습니다.";
                case SchedulerStringId.Msg_InvalidMonthCount: return " 잘못 된 개월 수입니다. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidMonthCountValue: return " 잘못 된 개월 수입니다. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidOccurrencesCount: return " 유효 하지 않은 항목 포함. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidOccurrencesCountValue: return " 유효 하지 않은 항목 포함. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidReminderTimeBeforeStart: return " 잘못 된 값에 대해 지정 된 이벤트 알림 시간 전에. 양수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidSize: return " 크기에 지정 된 잘못 된 값.";
                case SchedulerStringId.Msg_InvalidTimeOfDayInterval: return " TimeOfDayInterval에 대 한 잘못 된 기간";
                case SchedulerStringId.Msg_InvalidWeekCount: return " 잘못 된 주 수입니다. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_InvalidWeekCountValue: return " 잘못 된 주 수입니다. 양의 정수 값을 입력 해 주시기 바랍니다.";
                case SchedulerStringId.Msg_IsNotValid: return " ' {0} '은 '{1}'에 대 한 유효한 값이 아닌";
                case SchedulerStringId.Msg_LoadCollectionFromXml: return " 스케줄러 xml에서 컬렉션 항목을 로드 하도록 언바운드 모드에 있이 필요가";
                case SchedulerStringId.Msg_MappingsCheckPassedOk: return " 매핑 검토가 정상입니다!";
                case SchedulerStringId.Msg_MemoPrintNoSelectedItems: return " 항목을 선택 하지 않으면 인쇄할 수 없습니다. 항목을 선택 하 고 다음 다시 인쇄해 봅니다.";
                case SchedulerStringId.Msg_MissingMappingMember: return " 누락 '{1}' 멤버 '{0}' 속성 매핑의.";
                case SchedulerStringId.Msg_NoMappingForObject: return " 개체 {0}에 대 한 다음 필요한 매핑을 할당 되지 않은";
                case SchedulerStringId.Msg_OutlookCalendarNotFound: return " '{0}' 일정을 찾을 수 없습니다.";
                case SchedulerStringId.Msg_PrintStyleNameExists: return " 스타일 이름이 ' {0} '에 이미 존재 합니다. 다른 이름을 입력 합니다.";
                case SchedulerStringId.Msg_Warning: return " 경고!";
                case SchedulerStringId.Msg_XtraSchedulerNotAssigned: return " SchedulerStorage 구성 요소는 SchedulerControl에 할당 되지 않은";
                case SchedulerStringId.PrintCalendarDetailsControlDayPeriod: return " 일";
                case SchedulerStringId.PrintCalendarDetailsControlMonthPeriod: return " 달";
                case SchedulerStringId.PrintCalendarDetailsControlWeekPeriod: return " 주";
                case SchedulerStringId.PrintMonthlyOptControlOnePagePerMonth: return " 1 페이지/월";
                case SchedulerStringId.PrintMonthlyOptControlTwoPagesPerMonth: return " 2 페이지/월";
                case SchedulerStringId.PrintMoreItemsMsg: return " 더 많은 아이템...";
                case SchedulerStringId.PrintNoPrintersInstalled: return " 프린터가 설치되어 있지 않습니다";
                case SchedulerStringId.PrintPageSetupFormatTabControlSizeAndFontName: return " {0} pt. {1}";
                case SchedulerStringId.PrintPageSetupFormCaption: return " 인쇄 옵션: {0}";
                case SchedulerStringId.PrintTriFoldOptControlDailyCalendar: return " 일일 일정";
                case SchedulerStringId.PrintTriFoldOptControlMonthlyCalendar: return " 월간 일정";
                case SchedulerStringId.PrintTriFoldOptControlWeeklyCalendar: return " 주간 일정";
                case SchedulerStringId.PrintWeeklyOptControlOneWeekPerPage: return " 1 페이지/주";
                case SchedulerStringId.PrintWeeklyOptControlTwoWeekPerPage: return " 2 페이지/주";
                case SchedulerStringId.Reporting_NotAssigned_TimeCells: return " 필요한 TimeCells 컨트롤이 할당되지 않습니다.";
                case SchedulerStringId.Reporting_NotAssigned_View: return " 필요한 뷰 구성 요소가 할당 되지 않은";
                case SchedulerStringId.TextAppointmentSnapToCells_Always: return " 항상";
                case SchedulerStringId.TextAppointmentSnapToCells_Auto: return " 자동";
                case SchedulerStringId.TextAppointmentSnapToCells_Disabled: return " 사용 안 함";
                case SchedulerStringId.TextAppointmentSnapToCells_Never: return " 결코";
                case SchedulerStringId.TextDailyPatternString_EveryDay: return " 각 {1} {0}";
                case SchedulerStringId.TextDailyPatternString_EveryDays: return " 각 {2} {1} {0}";
                case SchedulerStringId.TextDailyPatternString_EveryWeekDay: return " 각 평일 {0}";
                case SchedulerStringId.TextDailyPatternString_EveryWeekend: return " 각 주말 {0}";
                case SchedulerStringId.TextDuration_ForPattern: return " {0} {1}";
                case SchedulerStringId.TextDuration_FromForDays: return " {1}에 {0}에서";
                case SchedulerStringId.TextDuration_FromForDaysHours: return " {1} {2}에 대 한 {0}에서";
                case SchedulerStringId.TextDuration_FromForDaysHoursMinutes: return " {2} {3} {1}에 {0}에서";
                case SchedulerStringId.TextDuration_FromForDaysMinutes: return " {3} {1}에 {0}에서";
                case SchedulerStringId.TextDuration_FromTo: return " {1}에 {0}에서";
                case SchedulerStringId.TextMinutelyPatternString_EveryHour: return " 각 {0}";
                case SchedulerStringId.TextMinutelyPatternString_EveryHours: return " 각 {1} {0}";
                case SchedulerStringId.TextMinutelyPatternString_EveryMinute: return " 각 {0}";
                case SchedulerStringId.TextMinutelyPatternString_EveryMinutes: return " 각 {1} {0}";
                case SchedulerStringId.TextMonthlyPatternString_SubPattern: return " 모든 {0} {1}의 {2}의";
                case SchedulerStringId.TextMonthlyPatternString1: return " day {0} {3}";
                case SchedulerStringId.TextMonthlyPatternString2: return " the {0} {1} {2}";
                case SchedulerStringId.TextRecurrenceTypeDaily: return " 매일";
                case SchedulerStringId.TextRecurrenceTypeHourly: return " 시간별";
                case SchedulerStringId.TextRecurrenceTypeMonthly: return " 매월";
                case SchedulerStringId.TextRecurrenceTypeWeekly: return " 매주";
                case SchedulerStringId.TextRecurrenceTypeYearly: return " 매년";
                case SchedulerStringId.TextWeekly_0Day: return " 지정 되지 않은 요일";
                case SchedulerStringId.TextWeekly_1Day: return " {0}";
                case SchedulerStringId.TextWeekly_2Day: return " {0} 및 {1}";
                case SchedulerStringId.TextWeekly_3Day: return " {0}, {1} 및 {2}";
                case SchedulerStringId.TextWeekly_4Day: return " {0}, {1}, {2}, 그리고 {3}";
                case SchedulerStringId.TextWeekly_5Day: return " {0}, {1}, {2}, {3}, 그리고 {4}";
                case SchedulerStringId.TextWeekly_6Day: return " {0}, {1}, {2}, {3}, {4}, 그리고 {5}";
                case SchedulerStringId.TextWeekly_7Day: return " {0}, {1}, {2}, {3}, {4}, {5}, 그리고 {6}";
                case SchedulerStringId.TextWeeklyPatternString_EveryWeek: return " 각 {3} {0}";
                case SchedulerStringId.TextYearlyPattern_YearString1: return " 각 {3} {4} {0}";
                case SchedulerStringId.TextYearlyPattern_YearString2: return " the {0} of {5} {6}";
                case SchedulerStringId.TimeScaleDisplayName_Day: return " 일";
                case SchedulerStringId.TimeScaleDisplayName_Hour: return " 시간";
                case SchedulerStringId.TimeScaleDisplayName_Month: return " 달";
                case SchedulerStringId.TimeScaleDisplayName_Quarter: return " 분기";
                case SchedulerStringId.TimeScaleDisplayName_Week: return " 주";
                case SchedulerStringId.TimeScaleDisplayName_WorkDay: return " 근무일";
                case SchedulerStringId.TimeScaleDisplayName_WorkHour: return " 근무 시간";
                case SchedulerStringId.TimeScaleDisplayName_Year: return " 년";
                case SchedulerStringId.UD_SchedulerReportsToolboxCategoryName: return " 스케줄러 컨트롤";
                case SchedulerStringId.ViewDisplayName_Day: return " 하루 일정";
                case SchedulerStringId.ViewDisplayName_FullWeek: return " 전체 주 달력";
                case SchedulerStringId.ViewDisplayName_Gantt: return " 간트 뷰";
                case SchedulerStringId.ViewDisplayName_Month: return " 한달 일정";
                case SchedulerStringId.ViewDisplayName_Timeline: return " 시각표 일정";
                case SchedulerStringId.ViewDisplayName_Week: return " 주 달력";
                case SchedulerStringId.ViewDisplayName_WorkDays: return " 주(주말 제외) 일정";
                case SchedulerStringId.ViewShortDisplayName_Day: return " 일";
                case SchedulerStringId.ViewShortDisplayName_FullWeek: return " 전체 주";
                case SchedulerStringId.ViewShortDisplayName_Gantt: return " Gantt";
                case SchedulerStringId.ViewShortDisplayName_Month: return " 달";
                case SchedulerStringId.ViewShortDisplayName_Timeline: return " 타임 라인";
                case SchedulerStringId.ViewShortDisplayName_Week: return " 주";
                case SchedulerStringId.ViewShortDisplayName_WorkDays: return " 작업 주";
                case SchedulerStringId.ViewShortDisplayName_Year: return " 년";
                case SchedulerStringId.VS_SchedulerReportsToolboxCategoryName: return " DX {0} : 스케줄러 보고서";
                case SchedulerStringId.MenuCmd_SwitchToFullWeekView: return " 전체주간 뷰";
                    //case SchedulerStringId.MenuCmd_SwitchToAgendaView:
                    //    return "아젠다 뷰";
            }
            return base.GetLocalizedString(id);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(SchedulerStringId id)
        //{
        //    switch (id)
        //    {
        //        case SchedulerStringId.Caption_5Minutes:
        //            return "5 분";
        //        case SchedulerStringId.Caption_6Minutes:
        //            return "6 분";
        //        case SchedulerStringId.Caption_10Minutes:
        //            return "10 분";
        //        case SchedulerStringId.Caption_15Minutes:
        //            return "15 분";
        //        case SchedulerStringId.Caption_20Minutes:
        //            return "20 분";
        //        case SchedulerStringId.Caption_30Minutes:
        //            return "30 분";
        //        case SchedulerStringId.Caption_60Minutes:
        //            return "60 분";
        //        case SchedulerStringId.MenuCmd_GotoDate:
        //            return "날짜로 이동...";
        //        case SchedulerStringId.MenuCmd_GotoThisDay:
        //            return "이 날짜로 이동";
        //        case SchedulerStringId.MenuCmd_GotoToday:
        //            return "오늘 날짜로 이동";
        //        case SchedulerStringId.MenuCmd_NavigateBackward:
        //            return "이전으로 이동";
        //        case SchedulerStringId.MenuCmd_NavigateForward:
        //            return "앞으로 이동";
        //        case SchedulerStringId.MenuCmd_10Minutes:
        //            return "10분";
        //        case SchedulerStringId.MenuCmd_SwitchToDayView:
        //            return "일간 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchToFullWeekView:
        //            return "전체주간 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchToWeekView:
        //            return "주간 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchToWorkWeekView:
        //            return "근무주간 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchToMonthView:
        //            return "월간 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchToGanttView:
        //            return "간트 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchToTimelineView:
        //            return "타임라인 뷰";
        //        case SchedulerStringId.MenuCmd_SwitchViewMenu:
        //            return "뷰 바꾸기";
        //        //case SchedulerStringId.MenuCmd_SwitchToAgendaView:
        //        //    return "아젠다 뷰";
        //    }
        //    return base.GetLocalizedString(id);
        //}
    }
}
