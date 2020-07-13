using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cysharp.Threading.Tasks;
using UniRx;
using System.Threading;
using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Server/ServerConnector")]
    public class ServerConnector :
        ScriptableObject,
        IInRoomCallbacks,
        IConnectionCallbacks,
        IMatchmakingCallbacks
    {

        public static readonly RoomOptions randomRoomOptions = new RoomOptions() {
                IsVisible = true,
                IsOpen = true,
                MaxPlayers = 2
            };

        public static readonly RoomOptions specificRoomOptions = new RoomOptions() {
            IsVisible = false,
            IsOpen = true,
            MaxPlayers = 2
        };

        public static readonly TypedLobby lobbyType = TypedLobby.Default;

        [SerializeField]
        GameEvent ConnectingEvent;

        [SerializeField]
        GameEvent DisconnectingEvent;

        [SerializeField]
        GameEvent JoiningRoomEvent;

        [SerializeField]
        GameEvent LeaveingRoomEvent;

        [SerializeField]
        GameEvent ConnectedEvent;

        [SerializeField]
        GameEvent DisconnectedEvent;

        [SerializeField]
        GameEvent JoinedRoomEvent;

        [SerializeField]
        GameEvent LeftRoomEvent;

        [SerializeField]
        GameEvent PlayerEnteredRoomEvent;

        [SerializeField]
        GameEvent PlayerLeftRoomEvent;

        public void Activate() {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Deactivate() {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void SetNickname(string nickname) {
            PhotonNetwork.NickName = nickname;
        }

        public string GetSelfNickname() {
            return PhotonNetwork.LocalPlayer.NickName;
        }

        public string GetOpponentNickname() {
            return PhotonNetwork.PlayerListOthers[0]?.NickName;
        }

        public int GetPlayerInRoomCount() {
            return PhotonNetwork.CountOfPlayersInRooms;
        }

        public int GetOnlinePlayerCount() {
            return PhotonNetwork.CountOfPlayers;
        }

        public bool GetIsRoomVisible() {
            return PhotonNetwork.CurrentRoom.IsVisible;
        }

        public string GetRoomId() {
            return PhotonNetwork.CurrentRoom.Name;
        }

        public int GetPlayerInCurrentRoomCount() {
            return PhotonNetwork.CurrentRoom.PlayerCount;
        }

        public int GetMaxPlayerInRoomCount() {
            return PhotonNetwork.CurrentRoom.MaxPlayers;
        }

        public bool GetIsMasterClient() {
            return PhotonNetwork.LocalPlayer.IsMasterClient;
        }


        public async UniTask ConnectToServer() {
            if (PhotonNetwork.IsConnected) return;
            ConnectingEvent.Raise();
            PhotonNetwork.ConnectUsingSettings();
            await ConnectedEvent.OnRaise.GetAsyncEventHandler(CancellationToken.None).OnInvokeAsync();
        }

        public async UniTask MatchRandomRoom() {
            if (PhotonNetwork.InRoom) return;
            JoiningRoomEvent.Raise();
            PhotonNetwork.JoinRandomRoom();
            await JoinedRoomEvent.OnRaise.GetAsyncEventHandler(CancellationToken.None).OnInvokeAsync();
        }

        public async UniTask MatchSpecificRoom(string roomName) {
            if (PhotonNetwork.InRoom) return;
            JoiningRoomEvent.Raise();
            PhotonNetwork.JoinOrCreateRoom(roomName, specificRoomOptions, lobbyType);
            await JoinedRoomEvent.OnRaise.GetAsyncEventHandler(CancellationToken.None).OnInvokeAsync();
        }

        public async UniTask LeaveRoom() {
            if (!PhotonNetwork.InRoom) return;
            LeaveingRoomEvent.Raise();
            PhotonNetwork.LeaveRoom();
            await LeftRoomEvent.OnRaise.GetAsyncEventHandler(CancellationToken.None).OnInvokeAsync();
        }

        public async UniTask DisconnectFromServer() {
            if (!PhotonNetwork.IsConnected) return;
            DisconnectingEvent.Raise();
            PhotonNetwork.Disconnect();
            await DisconnectedEvent.OnRaise.GetAsyncEventHandler(CancellationToken.None).OnInvokeAsync();
        }


        public void OnJoinedRoom() {
            JoinedRoomEvent.Raise();
        }

        void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message) {
            PhotonNetwork.CreateRoom(null, randomRoomOptions, lobbyType);
        }

        void IMatchmakingCallbacks.OnCreatedRoom() {
            JoinedRoomEvent.Raise();
        }

        public void OnLeftRoom() {
            LeftRoomEvent.Raise();
        }

        public void OnConnectedToMaster() {
            ConnectedEvent.Raise();
        }

        public void OnDisconnected(DisconnectCause cause) {
            DisconnectedEvent.Raise();
        }

        public void OnPlayerEnteredRoom(Player player) {
            PlayerEnteredRoomEvent.Raise();
        }

        public void OnPlayerLeftRoom(Player player) {
            PlayerLeftRoomEvent.Raise();
        }


        #region 未使用のインタフェースメソッド
        void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message) {}
        void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message) {}
        void IConnectionCallbacks.OnConnected() {}
        void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friends) {}
        void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage) {}
        void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data) {}
        void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler) {}
        void IInRoomCallbacks.OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {}
        void IInRoomCallbacks.OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) {}
        void IInRoomCallbacks.OnMasterClientSwitched(Player newMasterClient) {}
        #endregion

    }
}
