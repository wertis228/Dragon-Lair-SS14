ent-ComputerBankATMBase = { "" }
    .desc = { "" }
ent-ComputerBankATMDeposit = bank atm
    .desc = Used to deposit and withdraw funds from a personal bank account.
ent-ComputerBankATMWithdraw = bank atm withdraw-only
    .desc = Used to withdraw funds from a personal bank account, unable to deposit.
ent-ComputerBankATM = { ent-ComputerBankATMDeposit }
    .desc = { ent-ComputerBankATMDeposit.desc }
ent-ComputerWithdrawBankATM = { ent-ComputerBankATMWithdraw }
    .desc = { ent-ComputerBankATMWithdraw.desc }
ent-ComputerWallmountBankATM = { ent-ComputerBankATMDeposit }
    .suffix = Wallmount
    .desc = { ent-ComputerBankATMDeposit.desc }
ent-ComputerWallmountWithdrawBankATM = { ent-ComputerBankATMWithdraw }
    .suffix = Wallmount
    .desc = { ent-ComputerBankATMWithdraw.desc }
ent-ComputerBlackMarketBankATM = { ent-ComputerBankATMDeposit }
    .desc = Has some sketchy looking modifications and a sticker that says DEPOSIT FEE 30%
    .suffix = BlackMarket
ent-StationAdminBankATM = station administration console
    .desc = Used to pay out from the station's bank account