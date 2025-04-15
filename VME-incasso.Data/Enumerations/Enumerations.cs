using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VME.incasso.Data.Enumerations
{
    public enum DebtStatus
    {
        Pending = 0,
        ReminderSent = 1,
        SecondReminderSent = 2,
        PartiallyPaid = 3,
        FullyPaid = 4,
        LegalProceedings = 5,
        CourtSummonsIssued = 6,
        AwaitingCourtDecision = 7,
        JudgmentReceived = 8,
        Closed = 9,
        Disputed = 10
    }
}
