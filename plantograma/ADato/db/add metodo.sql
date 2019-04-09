ALTER TABLE Plantograma
  ADD metodo int;
  ALTER TABLE Plantograma
  ADD metodoD int;
update Plantograma set metodo=0, metodoD=0;
--select * from Plantograma