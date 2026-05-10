using SmartEquipment.Highway101Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

/// <summary>
/// H101CommonService의 요약 설명입니다.
/// </summary>
public class H101CommonService
{
    ///////////////////////////////////////////////////////////////////////////////////////////////
    // Constructor & Global Instance
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #region :: 전역변수 선언 ::

    private Dictionary<string, ManualResetEvent> syncs = new Dictionary<string, ManualResetEvent>();
    private Dictionary<string, object> monitors = new Dictionary<string, object>();
    private Dictionary<string, string> receivedMessages = new Dictionary<string, string>();

    private bool _reOnError = false;
    private bool _fallToPrimary = false;

    private string _messageName = "";
    private string _serviceAddress = "";
    private string _pingInterval = "";
    private string _pingTimeOut = "";
    private string _sourceChannel = "";
    private string _targetChannel = "";
    private string sServiceAddress = "";

    private object responseMonitorLock = new object();

    private SmartEquipment.Highway101Adapter.Highway101Service h101Service;
    private Exception initializeExceptionRaised;

    #endregion

    #region :: 생성자 ::

    /// <summary>
    /// 
    /// </summary>
    public H101CommonService()
    {
        monitors.Add("DCOLmgr", new object());
        monitors.Add("WORKmgr", new object());
        monitors.Add("RULEmgr", new object());
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageName"></param>
    /// <param name="sourceChannel"></param>
    /// <param name="targetChannel"></param>
	public H101CommonService(string messageName, string sourceChannel, string targetChannel) : this()
	{
        try
        {
            _serviceAddress = "16.100.5.51:10101";      //운영 : 16.100.5.51/52, 개발 : 166.79.4.91

            _messageName = messageName;

            _pingInterval = "1000";
            _pingTimeOut = "30000";
            _reOnError = false;
            _fallToPrimary = false;

            _sourceChannel = sourceChannel;
            _targetChannel = targetChannel;

            sServiceAddress = String.Format("{0}?pingInterval={1}&pingTimeout={2}&resendOnError={3}&fallbackToPrimary={4}", _serviceAddress, _pingInterval, _pingTimeOut, _reOnError, _fallToPrimary);

            //Console.WriteLine("******************** HighWay 101 connect config start ********************");
            //Console.WriteLine("ServiceAddress : " + sServiceAddress);
            //Console.WriteLine("SourceSubject : " + _sourceChannel);
            //Console.WriteLine("TargetSubject : " + _targetChannel);

            h101Service = new Highway101Service(sServiceAddress, _sourceChannel, "");
        }
        catch (Exception ex)
        {
            Console.WriteLine("******************** HighWay 101 connect config fail ********************");
            Console.WriteLine("HighWay 101 연결 설정 실패 : " + ex.ToString());
        }        
    }

    #endregion


    ///////////////////////////////////////////////////////////////////////////////////////////////
    // Event Handler(Highway101Service Event)
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #region :: Highway101Service Event ::

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="message"></param>
    private void h101Service_OnReceivedMessage(object sender, string message)
    {
        //throw new NotImplementedException();
        string key = GetElementValue(message, "TransactionID");
        //Console.WriteLine("[" + key + "][Received message] " + Environment.NewLine + message);
        lock (responseMonitorLock)
        {
            if (syncs.ContainsKey(key))
            {
                receivedMessages.Add(key, message);
                syncs[key].Set();
            }
            else
            {
                Console.WriteLine("[" + key + "][Received message, Key not found] " + Environment.NewLine + message);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    private void h101Service_OnSendMessageCompleted(string message)
    {
        message = Regex.Replace(message, "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]", "", RegexOptions.Compiled);
        message = System.Xml.Linq.XDocument.Parse(message).ToString();

        //Console.WriteLine("[SendCompleted message] " + Environment.NewLine + message);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    private void h101Service_OnException(Exception exception)
    {
        initializeExceptionRaised = exception;
        Console.WriteLine("highway101Service_OnException : " + initializeExceptionRaised.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionId"></param>
    private void h101Service_OnDisconnected(string sessionId)
    {
        //throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionId"></param>
    private void h101Service_OnConnected(string sessionId)
    {
        //throw new NotImplementedException();
    }

    #endregion


    ///////////////////////////////////////////////////////////////////////////////////////////////
    // Method(Private)
    ///////////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////////////////////////
    // Method(Public)
    ///////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Connect()
    {
        bool flag = false;

        try
        {
            h101Service.OnConnected += new OnConnectedDelegate(h101Service_OnConnected);
            h101Service.OnDisconnected += new OnDisconnectedDelegate(h101Service_OnDisconnected);
            h101Service.OnException += new Highway101Service.OnExceptionDelegate(h101Service_OnException);
            h101Service.OnSendMessageCompleted += new OnSendMessageCompletedDelegate(h101Service_OnSendMessageCompleted);
            h101Service.OnReceivedMessage += new OnMessageEventHandler(h101Service_OnReceivedMessage);

            h101Service.Connect();

            flag = true;

            Console.WriteLine("******************** HighWay 101 Connect Success ********************");
        }
        catch (Exception ex)
        {
            Console.WriteLine("******************** HighWay 101 Connect Fail ********************");
            Console.WriteLine("Connect Fail : " + ex.ToString());
            flag = false;
        }

        return flag;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="xmlData"></param>
    /// <param name="millisecondsTimeout"></param>
    /// <returns></returns>
    public string SendMessage(string xmlData, int millisecondsTimeout)
    {
        string result = "";

        string targetChannel = GetElementValue(xmlData, "TargetSubject");
        string transationID = GetElementValue(xmlData, "TransactionID");
        string targetMgr = targetChannel.Split('/').Last();

        if (!monitors.ContainsKey(targetMgr)) return "";

        lock (monitors[targetMgr])
        {
            try
            {
                syncs.Add(transationID, new ManualResetEvent(false));

                if (Connect())
                {
                    if (initializeExceptionRaised != null)
                        throw initializeExceptionRaised;

                    h101Service.SendMessage(sServiceAddress, _targetChannel, xmlData);
                    syncs[transationID].WaitOne(millisecondsTimeout);

                    lock (responseMonitorLock)
                    {
                        if (receivedMessages.ContainsKey(transationID))
                        {
                            result = receivedMessages[transationID];
                            receivedMessages.Remove(transationID);
                            Console.WriteLine("[" + transationID + "] Received message for send" + Environment.NewLine + result);
                        }
                        else
                        {
                            Console.WriteLine("[" + transationID + "] Timeout");
                        }
                        syncs.Remove(transationID);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("******************** HighWay 101 Message send fail ********************");
                Console.WriteLine("send Fail : " + ex.ToString());
            }
            finally
            {
                Disconnect();

                lock (responseMonitorLock)
                {
                    if (receivedMessages.ContainsKey(transationID))
                        receivedMessages.Remove(transationID);

                    if (syncs.ContainsKey(transationID))
                        syncs.Remove(transationID);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Disconnect()
    {
        if (h101Service != null)
        {
            h101Service.Disconnect();
            h101Service = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    public string GetElementValue(string message, string element)
    {
        string startElement = "<" + element + ">";
        string endElement = "</" + element + ">";

        string result = "";

        int startIndex = message.IndexOf(startElement);

        if (startIndex == -1) return "";

        startIndex += startElement.Length;

        int length = message.IndexOf(endElement) - startIndex;
        result = message.Substring(startIndex, length);

        return result;
    }
}