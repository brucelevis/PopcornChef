﻿#if ENABLE_UNITYWEBREQUEST

using System;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks
{
    public class UnityWebRequestException : Exception
    {
        public UnityWebRequest UnityWebRequest { get; }
#if UNITY_2020_2_OR_NEWER
        public UnityWebRequest.Result Result { get; }
#else
        public bool IsNetworkError { get; }
        public bool IsHttpError { get; }
#endif
        public string Error { get; }
        public string Text { get; }
        public long ResponseCode { get; }

        string msg;

        public UnityWebRequestException(UnityWebRequest unityWebRequest)
        {
            this.UnityWebRequest = unityWebRequest;
#if UNITY_2020_2_OR_NEWER
            this.Result = unityWebRequest.result;
#else
            this.IsNetworkError = unityWebRequest.isNetworkError;
            this.IsHttpError = unityWebRequest.isHttpError;
#endif
            this.Error = unityWebRequest.error;
            this.ResponseCode = unityWebRequest.responseCode;
            this.Text = unityWebRequest.downloadHandler.text;
        }

        public override string Message
        {
            get
            {
                if (msg == null)
                {
                    msg = Error + Environment.NewLine + Text;
                }
                return msg;
            }
        }
    }
}

#endif