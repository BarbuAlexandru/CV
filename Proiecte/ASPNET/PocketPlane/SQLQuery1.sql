Alter Table [dbo].[Reservations]
Add CONSTRAINT [FK_Reservations_Flights_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [dbo].[Flights] ([Id]) ON DELETE CASCADE
