﻿using main.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.service
{
    public interface ISoldTicketService
    {
        SoldTicket AddSoldTicket(SoldTicket soldTicket);
    }
}
