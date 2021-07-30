namespace IODManager
{
    class KomorkaOrg
    {
        public long IdKomOrg { get; set; }
        public string SymbolKomOrg { get; set; }
        public string NazwaKomOrg { get; set; }
        public string OpisKomOrg { get; set; }

        public KomorkaOrg(int ID, string Sym, string Naz, string Op)
        {
            IdKomOrg = ID;
            SymbolKomOrg = Sym;
            NazwaKomOrg = Naz;
            OpisKomOrg = Op;
        }


    }


}
