// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.Character id) => GetViews(nameof(UIViewId.Character), id.ToString());
        public static void Show(UIViewId.Character id, bool instant = false) => Show(nameof(UIViewId.Character), id.ToString(), instant);
        public static void Hide(UIViewId.Character id, bool instant = false) => Hide(nameof(UIViewId.Character), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.InGame id) => GetViews(nameof(UIViewId.InGame), id.ToString());
        public static void Show(UIViewId.InGame id, bool instant = false) => Show(nameof(UIViewId.InGame), id.ToString(), instant);
        public static void Hide(UIViewId.InGame id, bool instant = false) => Hide(nameof(UIViewId.InGame), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Master id) => GetViews(nameof(UIViewId.Master), id.ToString());
        public static void Show(UIViewId.Master id, bool instant = false) => Show(nameof(UIViewId.Master), id.ToString(), instant);
        public static void Hide(UIViewId.Master id, bool instant = false) => Hide(nameof(UIViewId.Master), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Shared id) => GetViews(nameof(UIViewId.Shared), id.ToString());
        public static void Show(UIViewId.Shared id, bool instant = false) => Show(nameof(UIViewId.Shared), id.ToString(), instant);
        public static void Hide(UIViewId.Shared id, bool instant = false) => Hide(nameof(UIViewId.Shared), id.ToString(), instant);
        public static IEnumerable<UIView> GetViews(UIViewId.Splash id) => GetViews(nameof(UIViewId.Splash), id.ToString());
        public static void Show(UIViewId.Splash id, bool instant = false) => Show(nameof(UIViewId.Splash), id.ToString(), instant);
        public static void Hide(UIViewId.Splash id, bool instant = false) => Hide(nameof(UIViewId.Splash), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum Character
        {
            CharacterList
        }

        public enum InGame
        {
            Pause,
            Play
        }

        public enum Master
        {
            BattleVS,
            Character,
            Clan,
            Equipment,
            Iventory,
            Lobby,
            Mission,
            Ranking,
            Rune,
            SeasonPass,
            Setting,
            Shop,
            Stage,
            UserInfo
        }

        public enum Shared
        {
            NetworkError
        }
        public enum Splash
        {
            Home,
            Loader
        }    
    }
}
