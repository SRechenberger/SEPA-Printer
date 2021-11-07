using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SEPA_Printer
{
    class SEPACarrier
    {
        public string Receiver { get; private set; }
        public string ReceiverIBAN { get; private set; }
        public string ReceiverBIC { get; private set; }
        public string SenderUsage1 { get; private set; }
        public string SenderUsage2 { get; private set; }
        public string SenderIdent { get; private set; }
        public string SenderIBAN { get; private set; }
        public float Amount { get; private set; }

        [JsonConstructor]
        public SEPACarrier(
            String Receiver,
            String ReceiverIBAN,
            String ReceiverBIC,
            float Amount,
            String SenderUsage1,
            String SenderUsage2,
            String SenderIdent,
            String SenderIBAN)
        {
            if (Receiver.Length <= 27) this.Receiver = Receiver;
            else throw new ArgumentException($"Empfänger mit {Receiver.Length} Stellen zu lang. Maximal 27 Stellen.");

            if (ReceiverIBAN.Length == 22 || ReceiverIBAN.Length == 34) this.ReceiverIBAN = ReceiverIBAN;
            else throw new ArgumentException($"Empfänger-IBAN mit {ReceiverIBAN.Length} Stellen ungültig. Gültig nur mit 22 oder 34 Stellen.");

            if (ReceiverBIC.Length == 8 || ReceiverBIC.Length == 11) this.ReceiverBIC = ReceiverBIC;
            else throw new ArgumentException($"BIC mit {ReceiverBIC.Length} Stellen ungültig. Gültig nur mit 8 oder 11 Stellen.");

            if (Amount > 0) this.Amount = Amount;
            else throw new ArgumentException($"Betrag {Amount} ungültig. Muss größer 0 sein.");

            if (SenderUsage1.Length <= 27) this.SenderUsage1 = SenderUsage1;
            else throw new ArgumentException($"Verwendungszweck Zeile 1 mit {SenderUsage1.Length} ungültig. Maximal 27 Stellen.");

            if (SenderUsage2.Length <= 27) this.SenderUsage2 = SenderUsage1;
            else throw new ArgumentException($"Verwendungszweck Zeile 2 mit {SenderUsage2.Length} ungültig. Maximal 27 Stellen.");

            if (SenderIdent.Length <= 27) this.SenderIdent = SenderIdent;
            else throw new ArgumentException($"Zahler mit {SenderIdent.Length} Stellen ungültig. Maximal 27 Stellen.");

            if (SenderIBAN.Length != 22) throw new ArgumentException($"Zahler-IBAN mit {SenderIBAN.Length} Stellen ungültig. Nur gültig mit 22 Stellen.");
            if (SenderIBAN.Substring(0, 2) != "DE") throw new ArgumentException($"Zahler-IBAN mit Anfang {SenderIBAN.Substring(0, 2)} keine deutsche IBAN.");
            this.SenderIBAN = SenderIBAN;
        }


        public string Save()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
