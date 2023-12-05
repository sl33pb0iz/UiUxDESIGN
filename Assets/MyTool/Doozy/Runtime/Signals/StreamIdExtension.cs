// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using UnityEngine;
// ReSharper disable All

namespace Doozy.Runtime.Signals
{
    public partial class Signal
    {
        public static bool Send(StreamId.Master id, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), message);
        public static bool Send(StreamId.Master id, GameObject signalSource, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalSource, message);
        public static bool Send(StreamId.Master id, SignalProvider signalProvider, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalProvider, message);
        public static bool Send(StreamId.Master id, Object signalSender, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalSender, message);
        public static bool Send<T>(StreamId.Master id, T signalValue, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalValue, message);
        public static bool Send<T>(StreamId.Master id, T signalValue, GameObject signalSource, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalValue, signalSource, message);
        public static bool Send<T>(StreamId.Master id, T signalValue, SignalProvider signalProvider, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalValue, signalProvider, message);
        public static bool Send<T>(StreamId.Master id, T signalValue, Object signalSender, string message = "") => SignalsService.SendSignal(nameof(StreamId.Master), id.ToString(), signalValue, signalSender, message);

        public static bool Send(StreamId.Splash id, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), message);
        public static bool Send(StreamId.Splash id, GameObject signalSource, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalSource, message);
        public static bool Send(StreamId.Splash id, SignalProvider signalProvider, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalProvider, message);
        public static bool Send(StreamId.Splash id, Object signalSender, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalSender, message);
        public static bool Send<T>(StreamId.Splash id, T signalValue, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalValue, message);
        public static bool Send<T>(StreamId.Splash id, T signalValue, GameObject signalSource, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalValue, signalSource, message);
        public static bool Send<T>(StreamId.Splash id, T signalValue, SignalProvider signalProvider, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalValue, signalProvider, message);
        public static bool Send<T>(StreamId.Splash id, T signalValue, Object signalSender, string message = "") => SignalsService.SendSignal(nameof(StreamId.Splash), id.ToString(), signalValue, signalSender, message);   
    }

    public partial class StreamId
    {
        public enum Master
        {
            Card,
            Character,
            Clan,
            Equipment,
            Inventory,
            Lobby,
            Mission,
            Ranking,
            Rune,
            SeasonPass,
            Shop,
            Stage
        }

        public enum Splash
        {
            SignInAccountInGame
        }         
    }
}

