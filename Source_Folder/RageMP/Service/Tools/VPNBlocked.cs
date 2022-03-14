using System;
using GTANetworkAPI;

class VPNBlocker : Script
{

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Client player)
    {
        NAPI.Util.ConsoleOutput("[Loading] VPN Blocker Initialization...");
        NAPI.Util.ConsoleOutput("[Join] " + player.SocialClubName + " ");
            
        var blockedvpn = NAPI.Player.GetPlayerAddress(player);

        if (blockedvpn.Equals("59.15.205.233") ||
            (blockedvpn.Equals("119.175.155.76")) ||
            (blockedvpn.Equals("121.168.45.38")) ||
            (blockedvpn.Equals("210.217.15.184")) ||
            (blockedvpn.Equals("36.227.11.88")) ||
            (blockedvpn.Equals("1.238.79.152")) ||
            (blockedvpn.Equals("190.146.125.73")) ||
            (blockedvpn.Equals("219.118.121.76")) ||
            (blockedvpn.Equals("210.216.247.139")) ||
            (blockedvpn.Equals("126.73.112.52")) ||
            (blockedvpn.Equals("211.55.193.55")) ||
            (blockedvpn.Equals("184.82.77.15")) ||
            (blockedvpn.Equals("203.250.64.104")) ||
            (blockedvpn.Equals("121.153.45.35")) ||
            (blockedvpn.Equals("190.19.247.42")) ||
            (blockedvpn.Equals("110.163.143.10")) ||
            (blockedvpn.Equals("222.1.90.63")) ||
            (blockedvpn.Equals("61.74.24.104")) ||
            (blockedvpn.Equals("220.218.70.177")) ||
            (blockedvpn.Equals("221.119.221.214")) ||
            (blockedvpn.Equals("114.149.162.239")) ||
            (blockedvpn.Equals("118.159.64.174")) ||
            (blockedvpn.Equals("211.207.136.174")) ||
            (blockedvpn.Equals("218.217.124.231")) ||
            (blockedvpn.Equals("49.142.59.140")) ||
            (blockedvpn.Equals("73.239.14.25")) ||
            (blockedvpn.Equals("175.131.191.196")) ||
            (blockedvpn.Equals("218.158.82.201")) ||
            (blockedvpn.Equals("163.131.152.156")) ||
            (blockedvpn.Equals("121.163.44.82")) ||
            (blockedvpn.Equals("119.56.211.14")) ||
            (blockedvpn.Equals("42.150.164.42")) ||
            (blockedvpn.Equals("220.79.64.222")) ||
            (blockedvpn.Equals("118.155.104.114")) ||
            (blockedvpn.Equals("211.212.83.229")) ||
            (blockedvpn.Equals("118.32.76.189")) ||
            (blockedvpn.Equals("14.43.233.121")) ||
            (blockedvpn.Equals("39.116.21.17")) ||
            (blockedvpn.Equals("180.66.251.190")) ||
            (blockedvpn.Equals("180.68.31.121")) ||
            (blockedvpn.Equals("175.210.230.179")) ||
            (blockedvpn.Equals("78.85.4.30")) ||
            (blockedvpn.Equals("65.99.66.107")) ||
            (blockedvpn.Equals("184.22.58.167")) ||
            (blockedvpn.Equals("65.27.53.112")) ||
            (blockedvpn.Equals("119.196.48.137")) ||
            (blockedvpn.Equals("121.151.168.38")) ||
            (blockedvpn.Equals("121.130.188.116")) ||
            (blockedvpn.Equals("106.171.72.249")) ||
            (blockedvpn.Equals("210.136.183.107")) ||
            (blockedvpn.Equals("39.113.183.212")) ||
            (blockedvpn.Equals("1.4.186.192")) ||
            (blockedvpn.Equals("101.99.74.214")) ||
            (blockedvpn.Equals("27.6.71.123")) ||
            (blockedvpn.Equals("45.32.253.161")) ||
            (blockedvpn.Equals("202.182.126.55")) ||
            (blockedvpn.Equals("210.210.220.138")) ||
            (blockedvpn.Equals("114.109.124.64")) ||
            (blockedvpn.Equals("115.31.86.155")) ||
            (blockedvpn.Equals("171.247.24.192")) ||
            (blockedvpn.Equals("46.28.204.34")) ||
            (blockedvpn.Equals("218.148.113.35")) ||
            (blockedvpn.Equals("121.129.222.165")) ||
            (blockedvpn.Equals("121.158.57.140")) ||
            (blockedvpn.Equals("37.228.129.81")) ||
            (blockedvpn.Equals("207.148.111.200")) ||
            (blockedvpn.Equals("200.2.166.122")) ||
            (blockedvpn.Equals("184.22.37.153")) ||
            (blockedvpn.Equals("46.251.76.70")) ||
            (blockedvpn.Equals("183.91.3.207")) ||
            (blockedvpn.Equals("178.150.171.2")) ||
            (blockedvpn.Equals("124.217.249.24")) ||
            (blockedvpn.Equals("87.10.119.245")) ||
            (blockedvpn.Equals("181.117.160.128")) ||
            (blockedvpn.Equals("1.11.72.97")) ||
            (blockedvpn.Equals("103.250.73.38")) ||
            (blockedvpn.Equals("181.224.242.142")) ||
            (blockedvpn.Equals("115.77.125.26")) ||
            (blockedvpn.Equals("59.126.153.250")) ||
            (blockedvpn.Equals("95.24.28.31")) ||
            (blockedvpn.Equals("104.244.225.126")) ||
            (blockedvpn.Equals("175.212.91.131")) ||
            (blockedvpn.Equals("126.107.51.73")) ||
            (blockedvpn.Equals("103.216.218.19")) ||
            (blockedvpn.Equals("45.77.132.48")) ||
            (blockedvpn.Equals("222.114.60.79")) ||
            (blockedvpn.Equals("223.133.27.59")) ||
            (blockedvpn.Equals("37.120.154.14")) ||
            (blockedvpn.Equals("126.187.69.70")) ||
            (blockedvpn.Equals("103.201.129.74")) ||
            (blockedvpn.Equals("200.1.183.118")) ||
            (blockedvpn.Equals("211.203.11.53")) ||
            (blockedvpn.Equals("14.240.20.224")) ||
            (blockedvpn.Equals("182.221.196.19")) ||
            (blockedvpn.Equals("88.232.254.154")) ||
            (blockedvpn.Equals("203.232.195.82")) ||
            (blockedvpn.Equals("211.236.143.56")) ||
            blockedvpn.Equals("219.97.24.221"))
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Sie benutzen ein VPN!", true);
            //player.TriggerEvent("VPN_Blocker_Enable_Viewer");
            player.TriggerEvent("VPN_Blocker_Enable_Viewer");
            NAPI.Util.ConsoleOutput(blockedvpn + " - IP Blocked[VPN]");
            NAPI.Player.KickPlayer(player, "Denied");
        }
        else
        {

        }
    }
}