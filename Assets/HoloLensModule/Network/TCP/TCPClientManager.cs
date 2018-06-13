﻿using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_UWP
#elif UNITY_EDITOR || UNITY_STANDALONE
using System.Net.Sockets;
using System.Text;
using System.Threading;
#endif
using UnityEngine;

namespace HoloLensModule.Network
{
    public class TCPClientManager
    {
        public delegate void ListenerMessageEventHandler(string ms);
        public ListenerMessageEventHandler ListenerMessageEvent;

        public delegate void ListenerByteEventHandler(byte[] data);
        public ListenerByteEventHandler ListenerByteEvent;

#if UNITY_UWP
#elif UNITY_EDITOR || UNITY_STANDALONE
        private Thread mainthread = null;
        private Thread sendthread = null;
        private NetworkStream stream = null;
        private bool isActiveThread = false;
#endif
        public TCPClientManager() { }

        public TCPClientManager(string ipaddress, int port)
        {
            ConnectClient(ipaddress, port);
        }

        public void ConnectClient(string ipaddress, int port)
        {
#if UNITY_UWP
#elif UNITY_EDITOR || UNITY_STANDALONE
            if (mainthread == null)
            {
                mainthread = new Thread(()=>
                {
                    TcpClient tcpclient = new TcpClient(ipaddress, port);
                    tcpclient.ReceiveTimeout = 100;
                    stream = tcpclient.GetStream();
                    isActiveThread = true;
                    while (isActiveThread)
                    {
                        try
                        {
                            byte[] bytes = new byte[tcpclient.ReceiveBufferSize];
                            int num = stream.Read(bytes, 0, bytes.Length);
                            if (num > 0)
                            {
                                if (ListenerMessageEvent != null) ListenerMessageEvent(Encoding.UTF8.GetString(bytes));
                                if (ListenerByteEvent != null) ListenerByteEvent(bytes);
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e);
                        }
                    }
                    stream.Close();
                    tcpclient.Close();
                });
                mainthread.Start();
            }
#endif
        }

        public bool SendMessage(string ms)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ms);
            return SendMessage(bytes);
        }

        public bool SendMessage(byte[] data)
        {
#if UNITY_UWP
#elif UNITY_EDITOR || UNITY_STANDALONE
            if (sendthread == null || sendthread.ThreadState != ThreadState.Running)
            {
                sendthread = new Thread(() =>
                {
                    if (stream!=null)
                    {
                        stream.Write(data, 0, data.Length);
                    }
                });
                sendthread.Start();
                return true;
            }
#endif
            return false;
        }


        public void DisConnectClient()
        {
#if UNITY_UWP
#elif UNITY_EDITOR || UNITY_STANDALONE
            isActiveThread = false;
            if (mainthread != null)
            {
                mainthread.Abort();
                mainthread = null;
            }
            if (sendthread != null)
            {
                sendthread.Abort();
                sendthread = null;
            }
            stream = null;
#endif
        }
#if UNITY_UWP
#elif UNITY_EDITOR || UNITY_STANDALONE
#endif
    }
}
