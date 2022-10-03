
using Controller;
using Controller.Interfaces;
using Persistence;
using TestApp;

IWerknemerRepository werknemerRepository = new TestMapper();
IBezoekerRepository bezoekerRepository = new TestMapper();
IBedrijfRepository bedrijfRepository = new TestMapper();
IAfspraakRepository afspraakRepository = new TestMapper();

BezoekerController bezoekerController = new BezoekerController(werknemerRepository, bezoekerRepository,
    bedrijfRepository, afspraakRepository);

BeheerController beheerController = new BeheerController(werknemerRepository, bezoekerRepository,
    bedrijfRepository, afspraakRepository);

App app = new App(bezoekerController, beheerController);
app.StartUp();