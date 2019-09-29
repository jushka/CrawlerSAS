using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CrawlerSAS
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static async Task Main()
        {
            //string url = "https://classic.flysas.com/en/de/";
            string url = "https://book.flysas.com/pl/SASC/wds/Override.action?SO_SITE_EXT_PSPURL=https://classic.sas.dk/SASCredits/SASCreditsPaymentMaster.aspx&SO_SITE_TP_TPC_POST_EOT_WT=50000&SO_SITE_USE_ACK_URL_SERVICE=TRUE&WDS_URL_JSON_POINTS=ebwsprod.flysas.com%2FEAJI%2FEAJIService.aspx&SO_SITE_EBMS_API_SERVERURL=%20https%3A%2F%2F1aebwsprod.flysas.com%2FEBMSPointsInternal%2FEBMSPoints.asmx&WDS_SERVICING_FLOW_TE_SEATMAP=TRUE&WDS_SERVICING_FLOW_TE_XBAG=TRUE&WDS_SERVICING_FLOW_TE_MEAL=TRUE&WDS_MIN_REQ_MIL=500";

            //var values = new Dictionary<string, string>
            //{
            //    { "__EVENTTARGET", "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$Searchbtn$ButtonLink" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$ceptravelTypeSelector$TripTypeSelector", "roundtrip" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$hiddenIntercont", "False" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$hiddenDomestic", "SE,GB" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$txtFrom", "Stockholm, Sweden - Arlanda (ARN)" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$hiddenFrom", "ARN" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$txtTo", "London, United Kingdom - Heathrow (LHR)" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$hiddenTo", "LHR" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$predictiveSearch$txtFromTOJ", "Type a country, city or airport" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepCalendar$hiddenOutbound", "2019-10-07" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepCalendar$hiddenReturn", "2019-10-13" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepCalendar$hiddenStoreCalDates", "Tue Sep 24 2019 00:00:00 GMT+0300 (RytÅ³ Europos vasaros laikas),Tue Sep 24 2019 00:00:00 GMT+0300 (RytÅ³ Europos vasaros laikas),Thu Sep 17 2020 00:00:00 GMT+0300 (RytÅ³ Europos vasaros laikas)" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepCalendar$selectOutbound", "2019-09-01" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepCalendar$selectReturn", "2019-10-01" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$FlexDateSelector", "Show selected dates" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepPassengerTypes$passengerTypeAdult", "1" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepPassengerTypes$passengerTypeChild211", "0" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$cepPassengerTypes$passengerTypeInfant", "0" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$hdnsetDefaultValue", "true" },
            //    { "ctl00$FullRegion$MainRegion$ContentRegion$ContentFullRegion$ContentLeftRegion$CEPGroup1$CEPActive$cepNDPRevBookingArea$hdncalendarDropdown", "true" },
            //    { "__PREVIOUSPAGE", "3aoIK5urOF6qLmjEUVWoe7Zlok_H7Ef8UkS2oCFR_Ccg24aQSIRhidbF3PGeuRmIFTuiGxx8ealPNKfgqBWh77mCC2k1" },
            //    { "__VIEWSTATE", "/wEPDwUJNjIyMTczODM5D2QWAmYPZBYCAgEQZGQWAgIBD2QWAgICD2QWAgIDD2QWAgICD2QWBAIBD2QWAgIBD2QWAmYPZBYEZg8WAh4FY2xhc3MFCWFjdGl2ZUNFUBYWZg8VAQtCb29rIGEgdHJpcGQCBQ8PZBYCHgtDRVBQYWdlRGF0YQUXRVBpU2VydmVyLkNvcmUuUGFnZURhdGFkAgsPD2QWAh4TTm90aWZpY2F0aW9uQ29udHJvbAUuQVNQLnNhc190ZW1wbGF0ZXNfdXRpbF9ub3RpZmljYXRpb25kaWFsb2dfYXNjeBYIAgUPZBYCAgEPEA8WAh4LXyFEYXRhQm91bmRnZGQWAGQCCQ8PFgQeC19pc0VkaXRhYmxlaB4JX3BhZ2VMaW5rKClsRVBpU2VydmVyLkNvcmUuUGFnZVJlZmVyZW5jZSwgRVBpU2VydmVyLCBWZXJzaW9uPTYuMS4zNzkuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj04ZmU4M2RlYTczOGI0NWI3BjIxNTQ2MWRkAgoPZBYCZg9kFgQCAQ8WAh4Fc3R5bGUFDmRpc3BsYXk6IGJsb2NrFgICAQ8WAh4JaW5uZXJodG1sBT88c3R5bGU+DQouYWN0aXZlQ0VQe3otaW5kZXg6MTAwOyBwb3NpdGlvbjpyZWxhdGl2ZX0NCjwvc3R5bGU+DQpkAgMPEA8WAh8DZ2RkFgBkAgsPFQJBaHR0cDovL2NsYXNzaWMuZmx5c2FzLmNvbS9kZWZhdWx0LmFzcHg/aWQ9ODUxNyZhbXA7ZXBzbGFuZ3VhZ2U9ZW4FUmVzZXRkAg0PDxYCHgdWaXNpYmxlZxYCHwIFLkFTUC5zYXNfdGVtcGxhdGVzX3V0aWxfbm90aWZpY2F0aW9uZGlhbG9nX2FzY3gWDAIDD2QWAmYPFgIfCGcWAgIBD2QWAmYPZBYCZg9kFgYCAQ9kFgJmDxYCHgRUZXh0BbYBPGxhYmVsIGZvcj0iY3RsMDBfRnVsbFJlZ2lvbl9NYWluUmVnaW9uX0NvbnRlbnRSZWdpb25fQ29udGVudEZ1bGxSZWdpb25fQ29udGVudExlZnRSZWdpb25fQ0VQR3JvdXAxX0NFUEFjdGl2ZV9jZXBORFBSZXZCb29raW5nQXJlYV9jZXB0cmF2ZWxUeXBlU2VsZWN0b3Jfcm91bmR0cmlwIj5Sb3VuZCB0cmlwPC9sYWJlbD5kAgMPZBYCZg8WAh8JBbABPGxhYmVsIGZvcj0iY3RsMDBfRnVsbFJlZ2lvbl9NYWluUmVnaW9uX0NvbnRlbnRSZWdpb25fQ29udGVudEZ1bGxSZWdpb25fQ29udGVudExlZnRSZWdpb25fQ0VQR3JvdXAxX0NFUEFjdGl2ZV9jZXBORFBSZXZCb29raW5nQXJlYV9jZXB0cmF2ZWxUeXBlU2VsZWN0b3Jfb25ld2F5Ij5PbmUgd2F5PC9sYWJlbD5kAgUPZBYCZg8WAh8JBcIBPGxhYmVsIGZvcj0iY3RsMDBfRnVsbFJlZ2lvbl9NYWluUmVnaW9uX0NvbnRlbnRSZWdpb25fQ29udGVudEZ1bGxSZWdpb25fQ29udGVudExlZnRSZWdpb25fQ0VQR3JvdXAxX0NFUEFjdGl2ZV9jZXBORFBSZXZCb29raW5nQXJlYV9jZXB0cmF2ZWxUeXBlU2VsZWN0b3Jfb3BlbmphdyI+UmV0dXJuIGZyb20gYW5vdGhlciBjaXR5PC9sYWJlbD5kAgYPFgIfCGcWAgIBDxAPFgIfA2dkDxYCZgIBFgIQBRdTaG93IGEgbW9udGhseSBjYWxlbmRhcgUXU2hvdyBhIG1vbnRobHkgY2FsZW5kYXJnEAUTU2hvdyBzZWxlY3RlZCBkYXRlcwUTU2hvdyBzZWxlY3RlZCBkYXRlc2dkZAIHDxYCHwhnFgICAQ8WAh8HBX08Yj5Hcm91cCB0cmF2ZWw8L2I+IChtb3JlIHRoYW4gOSBwZW9wbGUpIDxhIGhyZWY9ImphdmFzY3JpcHQ6b3BlbkhlbHBQb3B1cCgnL2VuL3NoYXJlZC9zL0NvbnRhY3QtU0lBLS8nKSI+IGNvbnRhY3QgdXM8L2E+DQoNCmQCCA9kFgJmD2QWBgIBDxAPFgIfA2dkZGRkAgIPEA8WAh8DZ2RkZGQCAw8QDxYCHwNnZGRkZAIJD2QWAmYPZBYEAgEPFgIfBgUOZGlzcGxheTogYmxvY2sWAgIBDxYCHwcFPzxzdHlsZT4NCi5hY3RpdmVDRVB7ei1pbmRleDoxMDA7IHBvc2l0aW9uOnJlbGF0aXZlfQ0KPC9zdHlsZT4NCmQCAw8QDxYCHwNnZGRkZAIKDxUCLC90ZW1wbGF0ZXMvQ0VQLmFzcHg/aWQ9MjE1NDYxJmVwc2xhbmd1YWdlPWVuBVJlc2V0ZAIPDw9kFgIfAgUuQVNQLnNhc190ZW1wbGF0ZXNfdXRpbF9ub3RpZmljYXRpb25kaWFsb2dfYXNjeBYKAgQPZBYEZg9kFgRmDxUBG1RyYXZlbCBQYXNzIG51bWJlciBpbiB1c2UgOmQCAw9kFgJmDxUBGUNoYW5nZSBUcmF2ZWwgUGFzcyBudW1iZXJkAgIPZBYEAgEPEA8WAh8JBRhCb29rIGFzIGEgdHJhdmVsIG1hbmFnZXJkZGRkAgMPEA8WAh8JBRFPbmx5IG1lIHRyYXZlbGluZ2RkZGQCCA9kFgpmDxUBBlNlbGVjdGQCAw8QFgIfA2dkFCsBAGQCBg8QFgIfA2dkFCsBAGQCCg8QFgIfA2dkFCsBAGQCDQ8QFgIfA2dkFCsBAGQCDg9kFgICAg8VDAlUcmF2ZWxlcnMQU2VsZWN0IHRyYXZlbGVycwVDbG9zZRBTZWxlY3QgdHJhdmVsZXJzDWlzIHRyYXZlbGxpbmcDWWVzAk5vE051bWJlciBvZiB0cmF2ZWxlcnMIVHJhdmVsZXIOTm9uZSB0byBzZWxlY3QGU2VsZWN0Ak9LZAIQD2QWAmYPZBYEAgEPFgIfBgUOZGlzcGxheTogYmxvY2sWAgIBDxYCHwcFPzxzdHlsZT4NCi5hY3RpdmVDRVB7ei1pbmRleDoxMDA7IHBvc2l0aW9uOnJlbGF0aXZlfQ0KPC9zdHlsZT4NCmQCAw8QDxYCHwNnZGQWAGQCEQ8VAiwvdGVtcGxhdGVzL0NFUC5hc3B4P2lkPTIxNTQ2MSZlcHNsYW5ndWFnZT1lbgVSZXNldGQCEQ8PZBYCHwIFLkFTUC5zYXNfdGVtcGxhdGVzX3V0aWxfbm90aWZpY2F0aW9uZGlhbG9nX2FzY3gWBgIGD2QWBGYPFQEbVHJhdmVsIFBhc3MgbnVtYmVyIGluIHVzZSA6ZAIDD2QWAmYPFQEZQ2hhbmdlIFRyYXZlbCBQYXNzIG51bWJlcmQCDg9kFgJmD2QWBAIBDxYCHwYFDmRpc3BsYXk6IGJsb2NrFgICAQ8WAh8HBT88c3R5bGU+DQouYWN0aXZlQ0VQe3otaW5kZXg6MTAwOyBwb3NpdGlvbjpyZWxhdGl2ZX0NCjwvc3R5bGU+DQpkAgMPEA8WAh8DZ2RkFgBkAg8PFQIsL3RlbXBsYXRlcy9DRVAuYXNweD9pZD0yMTU0NjEmZXBzbGFuZ3VhZ2U9ZW4FUmVzZXRkAhMPD2QWAh8CBS5BU1Auc2FzX3RlbXBsYXRlc191dGlsX25vdGlmaWNhdGlvbmRpYWxvZ19hc2N4FgQCDA9kFgJmD2QWAgIDDxAPFgIfA2dkZBYAZAIND2QWAmYPFQENTW9kaWZ5IHNlYXJjaGQCFQ8PZBYCHwIFLkFTUC5zYXNfdGVtcGxhdGVzX3V0aWxfbm90aWZpY2F0aW9uZGlhbG9nX2FzY3gWBAILD2QWAmYPZBYCAgMPEA8WAh8DZ2RkFgBkAgwPZBYCZg8VAQ1Nb2RpZnkgc2VhcmNoZAIZD2QWAmYPZBYEZg8WAh8IaBYCZg8VAQBkAgEPFQEAZAIfD2QWBGYPFQJ0Y3RsMDBfRnVsbFJlZ2lvbl9NYWluUmVnaW9uX0NvbnRlbnRSZWdpb25fQ29udGVudEZ1bGxSZWdpb25fQ29udGVudExlZnRSZWdpb25fQ0VQR3JvdXAxX0NFUEFjdGl2ZV9DTVBDb2RlX2J0bkJvb2tOb3d0Y3RsMDBfRnVsbFJlZ2lvbl9NYWluUmVnaW9uX0NvbnRlbnRSZWdpb25fQ29udGVudEZ1bGxSZWdpb25fQ29udGVudExlZnRSZWdpb25fQ0VQR3JvdXAxX0NFUEFjdGl2ZV9DTVBDb2RlX2J0bkJvb2tOb3dkAgEPZBYEZg8VAhZCb29rIHNwb3J0IHRyYXZlbCBoZXJlHkNvcnBvcmF0ZSBhZ3JlZW1lbnQgY29kZSAoQ01QKWQCAw9kFgJmDxUBBEJvb2tkAiEPZBYEZg9kFgICAQ9kFgQCAQ8PFgIeDV9sYW5ndWFnZVRleHQFGVNlbGVjdCBUcmF2ZWwgUGFzcyBudW1iZXJkZAIDD2QWAgIBDw8WAh8KBQxDbG9zZSB3aW5kb3dkZAIBDxAPFgIfA2dkZBYAZAICD2QWBgIBDw8WAh8KBQVMb2dpbmRkAgMPDxYCHwoFDENsb3NlIHdpbmRvd2RkAgcPDxYCHwkFBUxvZ2luZGQCBQ9kFgQCAQ8PFgQfBGgeCV9sYXN0VHlwZQUHRGVmYXVsdGRkAgMPFgIfCGcWAgIBDw8WBB8EaB8LBQdEZWZhdWx0ZGQYAgUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFgUFlgFjdGwwMCRGdWxsUmVnaW9uJE1haW5SZWdpb24kQ29udGVudFJlZ2lvbiRDb250ZW50RnVsbFJlZ2lvbiRDb250ZW50TGVmdFJlZ2lvbiRDRVBHcm91cDEkQ0VQQWN0aXZlJGNlcE5EUFJldkJvb2tpbmdBcmVhJGNlcHRyYXZlbFR5cGVTZWxlY3RvciRyb3VuZHRyaXAFkwFjdGwwMCRGdWxsUmVnaW9uJE1haW5SZWdpb24kQ29udGVudFJlZ2lvbiRDb250ZW50RnVsbFJlZ2lvbiRDb250ZW50TGVmdFJlZ2lvbiRDRVBHcm91cDEkQ0VQQWN0aXZlJGNlcE5EUFJldkJvb2tpbmdBcmVhJGNlcHRyYXZlbFR5cGVTZWxlY3RvciRvbmV3YXkFkwFjdGwwMCRGdWxsUmVnaW9uJE1haW5SZWdpb24kQ29udGVudFJlZ2lvbiRDb250ZW50RnVsbFJlZ2lvbiRDb250ZW50TGVmdFJlZ2lvbiRDRVBHcm91cDEkQ0VQQWN0aXZlJGNlcE5EUFJldkJvb2tpbmdBcmVhJGNlcHRyYXZlbFR5cGVTZWxlY3RvciRvbmV3YXkFlAFjdGwwMCRGdWxsUmVnaW9uJE1haW5SZWdpb24kQ29udGVudFJlZ2lvbiRDb250ZW50RnVsbFJlZ2lvbiRDb250ZW50TGVmdFJlZ2lvbiRDRVBHcm91cDEkQ0VQQWN0aXZlJGNlcE5EUFJldkJvb2tpbmdBcmVhJGNlcHRyYXZlbFR5cGVTZWxlY3RvciRvcGVuamF3BZQBY3RsMDAkRnVsbFJlZ2lvbiRNYWluUmVnaW9uJENvbnRlbnRSZWdpb24kQ29udGVudEZ1bGxSZWdpb24kQ29udGVudExlZnRSZWdpb24kQ0VQR3JvdXAxJENFUEFjdGl2ZSRjZXBORFBSZXZCb29raW5nQXJlYSRjZXB0cmF2ZWxUeXBlU2VsZWN0b3Ikb3BlbmphdwV5Y3RsMDAkRnVsbFJlZ2lvbiRNYWluUmVnaW9uJENvbnRlbnRSZWdpb24kQ29udGVudEZ1bGxSZWdpb24kQ29udGVudExlZnRSZWdpb24kQ0VQR3JvdXAxJENFUEFjdGl2ZSRjaGlsZENFUExpc3QkTGV2ZWwyQ0VQcw8PZmRkbk4k0sNWpUCBE1ndEjupEBFsldo=" },
            //    { "__VIEWSTATEGENERATOR", "CA0B0334" },
            //};
            var values = new Dictionary<string, string>
            {
                { "__EVENTTARGET", "btnSubmitAmadeus" },
                { "__EVENTARGUMENT", "" },
                { "LANGUAGE", "GB" },
                { "SITE", "SKBKSKBK" },
                { "EMBEDDED_TRANSACTION", "FlexPricerAvailability" },
                { "SIP_INTERNAL", "44454641554C545F4E44505F4345505F49443D32313230383826504152414D455445525F434845434B53554D3D3633264345505F49443D3231353436312652454449524543545F55524C3D25326664656661756C742E617370782533666964253364383531372532366570736C616E6775616765253364656E265354415254504147455F49443D38353137264D41524B45543D4445265245565F5744535F4F42464545533D253363253366786D6C2B76657273696F6E25336427312E30272B656E636F64696E672533642769736F2D383835392D3127253366253365253363534F5F474C253365253363474C4F42414C5F4C4953542533652533634E414D45253365534954455F4C4953545F4F425F4645455F434F44455F544F5F4558454D50542533632532664E414D452533652533634C4953545F454C454D454E54253365253363434F4445253365543031253363253266434F44452533652533634C4953545F56414C55452533655430312533632532664C4953545F56414C55452533652533632532664C4953545F454C454D454E542533652533634C4953545F454C454D454E54253365253363434F4445253365543032253363253266434F44452533652533634C4953545F56414C55452533655430322533632532664C4953545F56414C55452533652533632532664C4953545F454C454D454E54253365253363253266474C4F42414C5F4C495354253365253363253266534F5F474C253365265245565F494E535552414E43453D253363253366786D6C2B76657273696F6E253364253232312E302532322B656E636F64696E6725336425323269736F2D383835392D31253232253366253365253363534F5F474C253365253363474C4F42414C5F4C4953542533652533634E414D45253365534954455F494E535552414E43455F50524F44554354532533632532664E414D452533652533634C4953545F454C454D454E54253365253363434F4445253365454154253363253266434F44452533652533634C4953545F56414C5545253365253363494E535552414E43455F434F44452533652533634555524F50455F4F57253365434F57452533632532664555524F50455F4F572533652533634555524F50455F5254253365435254452533632532664555524F50455F5254253365253363494E544552434F4E545F4F57253365434F5757253363253266494E544552434F4E545F4F57253365253363494E544552434F4E545F525425336543525457253363253266494E544552434F4E545F5254253365253363253266494E535552414E43455F434F44452533652533632532664C4953545F56414C55452533652533634C4953545F56414C55452533652533632532664C4953545F56414C55452533652533634C4953545F56414C55452533654E2533632532664C4953545F56414C55452533652533634C4953545F56414C55452533654E2533632532664C4953545F56414C55452533652533634C4953545F56414C55452533654E2533632532664C4953545F56414C55452533652533634C4953545F56414C55452533654E2533632532664C4953545F56414C55452533652533634C4953545F56414C5545253365312533632532664C4953545F56414C55452533652533632532664C4953545F454C454D454E54253365253363253266474C4F42414C5F4C495354253365253363253266534F5F474C253365" },
                { "WDS_FLOW", "REVENUE" },
                { "WDS_FACADE_CALLBACK", "https://classic.flysas.com/AmadeusFacade/default.aspx?epslanguage=en" },
                { "SO_SITE_ATC_ALLOW_LSA_INDIC", "TRUE" },
                { "SO_SITE_ADVANCED_CATEGORIES", "TRUE" },
                { "SO_SITE_TK_OFFICE_ID", "FRASK08RV" },
                { "SO_SITE_QUEUE_OFFICE_ID", "FRASK08RV" },
                { "SO_SITE_CSSR_TAXES", "FALSE" },
                { "SO_SITE_OFFICE_ID", "FRASK08RV" },
                { "SO_SITE_ETKT_Q_AND_CAT", "32C0" },
                { "SO_SITE_FP_CAL_DISP_NA_DATE", "TRUE" },
                { "SO_SITE_ETKT_Q_OFFICE_ID", "FRASK08RV" },
                { "SO_GL", "<SO_GL><GLOBAL_LIST><NAME>SITE_INSURANCE_PRODUCTS</NAME><LIST_ELEMENT><CODE>EAT</CODE><LIST_VALUE>CRTE</LIST_VALUE><LIST_VALUE></LIST_VALUE><LIST_VALUE>N</LIST_VALUE><LIST_VALUE>N</LIST_VALUE><LIST_VALUE>N</LIST_VALUE><LIST_VALUE>N</LIST_VALUE><LIST_VALUE>1</LIST_VALUE></LIST_ELEMENT></GLOBAL_LIST><GLOBAL_LIST><NAME>SITE_QUEUE_DEFINITION_LIST</NAME><LIST_ELEMENT><CODE>0</CODE><LIST_VALUE>SRV</LIST_VALUE><LIST_VALUE>FRASK08RV</LIST_VALUE><LIST_VALUE>34</LIST_VALUE><LIST_VALUE>0</LIST_VALUE></LIST_ELEMENT><LIST_ELEMENT><CODE>1</CODE><LIST_VALUE>CAN</LIST_VALUE><LIST_VALUE>FRASK08RV</LIST_VALUE><LIST_VALUE>31</LIST_VALUE><LIST_VALUE>0</LIST_VALUE></LIST_ELEMENT><LIST_ELEMENT><CODE>2</CODE><LIST_VALUE>RIR</LIST_VALUE><LIST_VALUE>FRASK08RV</LIST_VALUE><LIST_VALUE>30</LIST_VALUE><LIST_VALUE>0</LIST_VALUE></LIST_ELEMENT><LIST_ELEMENT><CODE>3</CODE><LIST_VALUE>REI</LIST_VALUE><LIST_VALUE>FRASK08RV</LIST_VALUE><LIST_VALUE>30</LIST_VALUE><LIST_VALUE>0</LIST_VALUE></LIST_ELEMENT><LIST_ELEMENT><CODE>4</CODE><LIST_VALUE>AWA</LIST_VALUE><LIST_VALUE>FRASK08RV</LIST_VALUE><LIST_VALUE>8</LIST_VALUE><LIST_VALUE>1</LIST_VALUE></LIST_ELEMENT><LIST_ELEMENT><CODE>6</CODE><LIST_VALUE>RIP</LIST_VALUE><LIST_VALUE>FRASK08RV</LIST_VALUE><LIST_VALUE>30</LIST_VALUE><LIST_VALUE>0</LIST_VALUE></LIST_ELEMENT></GLOBAL_LIST><GLOBAL_LIST><NAME>SITE_LIST_OB_FEE_CODE_TO_EXEMPT</NAME><LIST_ELEMENT><CODE>T01</CODE><LIST_VALUE>T01</LIST_VALUE></LIST_ELEMENT><LIST_ELEMENT><CODE>T02</CODE><LIST_VALUE>T02</LIST_VALUE></LIST_ELEMENT></GLOBAL_LIST></SO_GL>" },
                { "SO_SITE_FD_SOLDOUT_FLIGHT", "TRUE" },
                { "SO_SITE_QUEUE_CATEGORY", "8C50" },
                { "SO_SITE_ALLOW_LSA_INDICATOR", "TRUE" },
                { "WDS_SERVICING_FLOW_TE_MEAL", "TRUE" },
                { "WDS_AVD_SEL_FLIGHTS", "TRUE" },
                { "WDS_CAL_RANGE", "15" },
                { "WDS_SERVICING_FLOW_TE_FBAG", "TRUE" },
                { "WDS_SHOW_INVINFO", "FALSE" },
                { "WDS_BOOKING_FLOW_TE_MEAL", "TRUE" },
                { "WDS_ACTIVATE_APP_FOR_CC_MOP", "TRUE" },
                { "PRICING_TYPE", "C" },
                { "WDS_SHOW_TAXES", "TRUE" },
                { "B_LOCATION_1", "ARN" },
                { "WDS_FO_IATA", "23494925" },
                { "WDS_SHOW_ADDCAL", "TRUE" },
                { "WDS_INST_LIST", "SAScDE;klarna-SAScDE;klarna_nt" },
                { "WDS_USE_FQN", "TRUE" },
                { "WDS_ACTIVATE_APP_FOR_ALL_MOP", "FALSE" },
                { "COMMERCIAL_FARE_FAMILY_1", "SKSTDA" },
                { "WDS_CHECKIN_NOTIF", "FALSE" },
                { "TRIP_TYPE", "R" },
                { "WDS_HELPCONTACTURL", "http://classic.sas.se/en/misc/Arkiv/contact-sia-/" },
                { "WDS_SAS_CREDITS", "TRUE" },
                { "WDS_ANCILLARIES", "FALSE" },
                { "WDS_BOOKING_FLOW_TE_FBAG", "TRUE" },
                { "WDS_CC_LIST", "AX-SAS/ERETAIL_DE-true:CA-SAS/ERETAIL_DE-true:VI-SAS/ERETAIL_DE-true:DC-SAS/ERETAIL_DE-false:DS-SAS/ERETAIL_DE-true:TP-SAS/ERETAIL_DE-false" },
                { "WDS_SASCPCTRANGE", "2-6" },
                { "WDS_SHOW_AB", "TRUE" },
                { "WDS_FOID_EXCL_LIST", "DK" },
                { "DATE_RANGE_VALUE_1", "1" },
                { "WDS_SERVICING_FLOW_TE_SEATMAP", "TRUE" },
                { "DATE_RANGE_VALUE_2", "1" },
                { "WDS_BOOKING_FLOW_TE_XBAG", "TRUE" },
                { "WDS_POINTS_EARNED", "FALSE" },
                { "WDS_ORIGIN_SITE", "DE" },
                { "WDS_SHOW_CMP_CODE", "TRUE" },
                { "TRAVELLER_TYPE_1", "ADT" },
                { "WDS_NEWSLETTER_FCO", "FALSE" },
                { "B_LOCATION_2", "LHR" },
                { "WDS_BOOKING_FLOW_TE_SEATMAP", "TRUE" },
                { "WDS_TIME_OPTION", "True" },
                { "WDS_FRAS", "TRUE" },
                { "DISPLAY_TYPE", "2" },
                { "WDS_MOBILE_NEW_DESIGN", "TRUE" },
                { "WDS_SERVICING_FLOW_TE_XBAG", "TRUE" },
                { "WDS_SHOW_MINISEARCH", "LINK" },
                { "B_DATE_1", "201910070000" },
                { "B_DATE_2", "201910130000" },
                { "E_LOCATION_2", "ARN" },
                { "E_LOCATION_1", "LHR" },
                { "WDS_EBMS_CAMPAIGN", "TRUE" },
                { "DATE_RANGE_QUALIFIER_2", "C" },
                { "DATE_RANGE_QUALIFIER_1", "C" },
                { "WDS_INSTPAY", "TRUE" },
                { "ENCT", "1" },
                //{ "ENC", "B66868A73AFC25C4DB55A3A7A5799B7556AF720B973DF73E82B621B11131BBA9347E1B9DDE09436FAA12FE02EE1BB2B6723CDBF97A27DEDCB97EB08BDF6A478B2A0111FCE71421C05DBC9606E9548566821D54662375D7AC81DDA437353974A479F97CE986BFD45AD828EE94111443CD79F97CE986BFD45AD828EE94111443CD" },
                { "__PREVIOUSPAGE", "EOuVgEVGcPaooWlcQzY7uwfysikykaVpb-H5wZ3xp_fcVkbM_4Y3Yh3_OEwpzEWi5gOj_s80sjeP-1yYWe-Fp-6rsY8xAKiOA8--sL0aS3jICz0W0" },
                { "__VIEWSTATE", "/wEPDwUKMTE1MTc0MDk0N2RkuN2qfxyKJHLW+uU0D7+B8ZTdGMU=" },
                { "__VIEWSTATEGENERATOR", "BAA3076B" },
            };

            httpClient.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
            httpClient.DefaultRequestHeaders.Add("Origin", "https://classic.flysas.com");
            httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
            httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-site");
            httpClient.DefaultRequestHeaders.Add("Referer", "https://classic.flysas.com/en/de/");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "lt-LT,lt;q=0.9,en-US;q=0.8,en;q=0.7,ru;q=0.6,pl;q=0.5");
            //httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            //httpClient.DefaultRequestHeaders.Add("Cookie", "");

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string responseString = await response.Content.ReadAsStringAsync();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(responseString);

            string title = htmlDocument.DocumentNode.Descendants("title").FirstOrDefault().InnerText;
            //List<HtmlNode> prices = htmlDocument.DocumentNode.Descendants("span").Where(node => node.GetAttributeValue("class", "").Equals("number tobeupdated1")).ToList();

            Console.WriteLine(title);

            Console.ReadLine();
        }
    }
}