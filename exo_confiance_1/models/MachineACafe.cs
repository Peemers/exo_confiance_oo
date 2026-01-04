using System.Reflection.PortableExecutable;
using exo_confiance_1.enums;

namespace exo_confiance_1.models;

internal class MachineACafe
{
 internal CafeEtat EtatMachine { get; private set; }

 public MachineACafe()
 {
  EtatMachine = CafeEtat.Eteinte;
 }

 internal CafeEtat Action()
 {
  switch (EtatMachine)
  {
   case CafeEtat.Eteinte :
    EtatMachine = CafeEtat.Prete;
    break;
    
    case CafeEtat.Prete :
    EtatMachine = CafeEtat.EnPreparation;
    break;
    
    case CafeEtat.EnPreparation :
    EtatMachine = CafeEtat.Terminee;
    break;
    
    case CafeEtat.Terminee :
    EtatMachine = CafeEtat.Prete;
    break;
  }
  return EtatMachine;
 }
}