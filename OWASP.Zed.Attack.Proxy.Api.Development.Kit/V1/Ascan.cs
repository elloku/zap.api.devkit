using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Ascan;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1;

public class Ascan
{
    private const string ViewStatusUri = "/ascan/view/status/";
    private const string ViewScanProgressUri = "/ascan/view/scanProgress/";
    private const string ViewMessagesIdsUri = "";
    private const string ViewAlertsIdsUri = "";
    private const string ViewScansUri = "";
    private const string ViewScanPolicyNamesUri = "";
    private const string ViewExcludedFromScanUri = "";
    private const string ViewScannersUri = "";
    private const string ViewPoliciesUri = "";
    private const string ViewAttackModeQueueUri = "";
    private const string ViewExcludedParamsUri = "";
    private const string ViewOptionExcludedParamListUri = "";
    private const string ViewExcludedParamTypesUri = "";
    private const string ViewOptionAttackPolicyUri = "";
    private const string ViewOptionDefaultPolicyUri = "";
    private const string ViewOptionDelayInMsUri = "";
    private const string ViewOptionHandleAntiCSRFTokensUri = "";
    private const string ViewOptionHostPerScanUri = "";
    private const string ViewOptionMaxChartTimeInMinsUri = "";
    private const string ViewOptionMaxResultsToListUri = "";
    private const string ViewOptionMaxRuleDurationInMinsUri = "";
    private const string ViewOptionMaxScanDurationInMinsUri = "";
    private const string ViewOptionMaxScansInUIUri = "";
    private const string ViewOptionTargetParamsEnabledRPCUri = "";
    private const string ViewOptionTargetParamsInjectableUri = "";
    private const string ViewOptionThreadPerHostUri = "";
    private const string ViewOptionAddQueryParamUri = "";
    private const string ViewOptionAllowAttackOnStartUri = "";
    private const string ViewOptionInjectPluginIdInHeaderUri = "";
    private const string ViewOptionPromptInAttackModeUri = "";
    private const string ViewOptionPromptToClearFinishedScansUri = "";
    private const string ViewOptionRescanInAttackModeUri = "";
    private const string ViewOptionScanHeadersAllRequestsUri = "";
    private const string ViewOptionShowAdvancedDialogUri = "";
    private const string ActionScanUri = "/ascan/action/scan/";
    private const string ActionScanAsUserUri = "";
    private const string ActionPauseUri = "";
    private const string ActionResumeUri = "";
    private const string ActionStopUri = "";
    private const string ActionRemoveScanUri = "";
    private const string ActionPauseAllScansUri = "";
    private const string ActionResumeAllScansUri = "";
    private const string ActionStopAllScansUri = "";
    private const string ActionRemoveAllScansUri = "";
    private const string ActionClearExcludedFromScanUri = "";
    private const string ActionExcludeFromScanUri = "";
    private const string ActionEnableAllScannersUri = "";
    private const string ActionDisableAllScannersUri = "";
    private const string ActionEnableScannersUri = "";
    private const string ActionDisableScannersUri = "";
    private const string ActionSetEnabledPoliciesUri = "";
    private const string ActionSetPolicyAttackStrengthUri = "";
    private const string ActionSetPolicyAlertThresholdUri = "";
    private const string ActionSetScannerAttackStrengthUri = "";
    private const string ActionSetScannerAlertThresholdUri = "";
    private const string ActionAddScanPolicyUri = "";
    private const string ActionRemoveScanPolicyUri = "";
    private const string ActionUpdateScanPolicyUri = "";
    private const string ActionImportScanPolicyUri = "";
    private const string ActionAddExcludedParamUri = "";
    private const string ActionModifyExcludedParamUri = "";
    private const string ActionRemoveExcludedParamUri = "";
    private const string ActionSkipScannerUri = "";
    private const string ActionSetOptionAttackPolicyUri = "";
    private const string ActionSetOptionDefaultPolicyUri = "";
    private const string ActionSetOptionAddQueryParamUri = "";
    private const string ActionSetOptionAllowAttackOnStartUri = "";
    private const string ActionSetOptionDelayInMsUri = "";
    private const string ActionSetOptionHandleAntiCSRFTokensUri = "";
    private const string ActionSetOptionHostPerScanUri = "";
    private const string ActionSetOptionInjectPluginIdInHeaderUri = "";
    private const string ActionSetOptionMaxChartTimeInMinsUri = "";
    private const string ActionSetOptionMaxResultsToListUri = "";
    private const string ActionSetOptionMaxRuleDurationInMinsUri = "";
    private const string ActionSetOptionMaxScanDurationInMinsUri = "";
    private const string ActionSetOptionMaxScansInUIUri = "";
    private const string ActionSetOptionPromptInAttackModeUri = "";
    private const string ActionSetOptionPromptToClearFinishedScansUri = "";
    private const string ActionSetOptionRescanInAttackModeUri = "";
    private const string ActionSetOptionScanHeadersAllRequestsUri = "";
    private const string ActionSetOptionShowAdvancedDialogUri = "";
    private const string ActionSetOptionTargetParamsEnabledRPCUri = "";
    private const string ActionSetOptionTargetParamsInjectableUri = "";
    private const string ActionSetOptionThreadPerHostUri = "";

    private ZapApiClient _client;

    public Ascan(ZapApiClient client)
    {
        _client = client;
    }

    public async Task<IResponse?> ActionScan(string url, bool recurse, bool inScopeOnly, string scanPolicyName, string
        method, string postData, string contextId)
    {
        _client = new ZapApiClient(ActionScanUri);
        _client.AddParameters(new Dictionary<string, object?>()
        {
            {"url", url},
            {"recurse", recurse},
            {"inScopeOnly", inScopeOnly},
            {"scanPolicyName", scanPolicyName},
            {"method", method},
            {"postData", postData},
            {"contextId", contextId}
        });
        var response = await _client.GetAsync<ScanResponse>();
        return response;
    }
}