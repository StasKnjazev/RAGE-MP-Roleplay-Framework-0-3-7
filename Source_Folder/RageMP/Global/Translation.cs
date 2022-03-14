using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;


public class Translation : Script
{

    public static string COORDS_FROM = ",";
    public static string COORDS_TO = ",";

    public Translation()
    {
        //
    }

    public static string invalid_command = "Entschuldigung, dieser Befehl existiert nicht.";
    public static string chat_send_say = "sagt:";

    public static string message_error = "Error";
    public static string message_info = "Info";
    public static string message_warning = "Notice";
    public static string message_success = "Success";

    public static string chat_mask_type = "Mascarado_";
    public static string chat_cellphone_type = "(Celular)";
    public static string chat_unknow_type = "Desconhecido_";

    public static string vehicle_destroy_send_mors = "O seu {0} foi destruído e será enviado à seguradora.";
    public static string message_taxi_driver_exit_Vehicle = "~y~*~w~ Você deixou o taxi, você conseguiu um total de ~g~${0}~w~ pelas corridas feitas.";
    public static string message_taxi_passager_exit_Vehicle = "~y~*~w~ O taxista deixou o taxi, você pagou ~g~${0}~w~ para o taxista pela corrida.";
    public static string message_taxi_passager_exit_vehicle_2 = "~y~*~w~ Você deixou o taxi, e pagou um valor de ~g~${0}~w~ para o taxista pela corrida.";
    public static string message_taxi_passager_exit_vehicle_3 = "~y~*~w~ {0} deixou o taxi, Você recebeu um pagamento de {1} pela corrida.";
    public static string message_taxi_passager_exit_vehicle_4 = "~w~Você não tem como pagar o taxista, o preço da corrida desse taxi custa ~g~${0}~w~ a cada 10/s.";

    public static string message_01 = "O motor do seu veículo enguiçou. Para conserta-lo chame um mecânico.";
    public static string message_02 = "[Guerra de Territórios]:~w~ {0} foi morto no territorio {1}.";
    public static string message_03 = "[Guerra de Territórios]:~w~ Um membro da ~g~{0}~w~ foi morto no territorio ~y~{1}~w~.";
    public static string message_04 = "[Guerra de Territórios]:~w~ {0} foi morto por um membro da {1} no territorio ~y~{2}~w~.";
    public static string message_05 = "[Guerra de Territórios]:~w~ {0} matou um membro da {1} no territorio ~y~{2}~w~.";
    public static string message_06 = "Você está inconsciente, você foi levado imediatamente ao hospital.";
    public static string message_07 = "coloca a chave na ignição e tenta ligar o motor do veículo.";
    public static string message_08 = "~y~[INFO]:~w~ Você pagou sua divida com a sociedade, seja um cidadão e um jogador melhor agora !";
    public static string message_09 = "DICA: Siga as regras do servidor corretamente ou você poderá ser banido.";
    public static string message_10 = "Sua despesas médicas no ~y~Pillbox Hill Medical Center~w~ ficou em ~g~$2,500~w~, tenha um bom dia!";
    public static string message_11 = "~g~[TERRITORIO]:~w~ O territorio ~y~{0}~w~ está disponível para captura.";
    public static string message_12 = "~g~[TURF]:~w~Você recebeu ~g~$~y~{0}~w~, por manter a área {1} sob controle.";
    public static string message_13 = "Você não está em uma barbearia.";
    public static string message_14 = "Você não tem dinheiro suficiente para comprar este item.";
    public static string message_15 = "Nossa empresa está sem estoque no momento, porfavor volte mais tarde !";
    public static string message_16 = "Você comprou um item na barbearia por {0}.";
    public static string message_17 = "Você não pode fazer isto agora.";

    public static string notification_info_helmet = "Use o ~b~menu de interação~w~ para colocar o capacete.";
    public static string notification_info_seatbelt = "Use ~b~menu de interação~w~ para colocar o cinto de segurança.";
    public static string notification_enter_vehicle_ticket = "Este seu ~y~{0}~w~ está com uma multa de ~g~$ {1}~w~, vá até o ~b~DP~w~ paga-la.";

    public static string notification_1 = "Espere alguns segundos, e tente novamente ...";
    public static string notification_2 = "Dados incorreto !~n~Você digitou um nome de usuario ou senha incorretos.";
    public static string notification_3 = "Seu nick de usuario deve ter entre 4 a 30 caracteres.";
    public static string notification_4 = "A sua senha deve ter entre 4 a 30 caracteres.";
    public static string notification_5 = "Você deve usar um endereço de e-mail valido.";
    public static string notification_6 = "Você não possuí as chaves dessa casa.";
    public static string notification_7 = "Você " + Main.EMBED_LIGHTGREEN + "destrancou" + Main.EMBED_WHITE + " sua casa.";
    public static string notification_8 = "Você " + Main.EMBED_RED + "trancou" + Main.EMBED_WHITE + " sua casa.";
    public static string notification_9 = "Você está fora de serviço.";
    public static string notification_10 = "Você não pode estar dentro de um veículo.";
    public static string notification_11 = "Você ~g~entrou~w~ em serviço.";
    public static string notification_12 = "Você saiu~w~ de serviço.";
    public static string notification_13 = "Está porta está trancada.";
    public static string notification_14 = "O efeito da heroina acabou.";
    public static string notification_15 = "O efeito da maconha acabou.";
    public static string notification_16 = "Você pagou sua dívida à sociedade, você agora está livre para cometer mais crimes ou ser um cidadão melhor!";
    public static string notification_17 = "Você está morrendo de ~y~fome~w~ e de ~b~sede~w~!";
    public static string notification_18 = "Você está morrendo de ~y~fome~w~, vá comer algo antes que você morra !";
    public static string notification_19 = "Você está morrendo de ~b~sede~w~, vá beber algo antes que você morra !";

    public static string head_notification_0 = "O seu veículo sofreu uma batida muito forte, o motor do veículo enguiçou~w~.";
    public static string head_notification_1 = "Você ~g~destrancou~w~ o seu veículo";
    public static string head_notification_2 = "Você trancou~w~ o seu veículo";
    public static string head_notification_3 = "Você desligou~w~ o motor do veículo";
    public static string head_notification_4 = "Você não poder ligar o veículo enquanto está reabastecendo.";
    public static string head_notification_5 = "Você está tentando Ligar o motor do veículo ...";
    public static string head_notification_6 = "O motor do veículo está enguiçado,~w~ chame um ~y~mecânico~w~ para conserta-lo.";
    public static string head_notification_7 = "O motor do veículo está enguiçado,~w~ tente novamente ...";
    public static string head_notification_8 = "O veículo está sem combustivel,~w~ chame um ~y~mecânico~w~ para abastace-lo.";
    public static string head_notification_9 = "Você ~g~ligou~w~ o motor do veículo";
    public static string head_notification_10 = "Artikel sind derzeit nicht vorrätig.";
    public static string head_notification_11 = "Você você precisa está em serviço para usar o arsenal.";

    public static string ls_custom_label_free = "~b~** Drücke E";
    public static string ls_custom_label_busy = "~b~** Drücke E";

    public static string draw_engine_vehicle_off = "O motor deste veiculo esta desligado~w~, pressione ( ~y~Y~w~ ) para liga-lo";

    public static void Create_Mechanic_Menu(Client player)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Job annehmen", Description = "", RightLabel = "" });

        if (AccountManage.GetPlayerJob(player) == 7)
        {
            menu_item_list.Add(new { Type = 1, Name = "~g~Liste der verfügbaren Dienste", Description = "", RightLabel = "" });
        }
        InteractMenu.CreateMenu(player, "JOB_SHIPMENT", "LKW Fahrer", "~b~OPTIONEN:", false, NAPI.Util.ToJson(menu_item_list), false);
    }
}

