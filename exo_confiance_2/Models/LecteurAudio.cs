using exo_confiance_2.Enums;

namespace exo_confiance_2.Models;

internal class LecteurAudio
{
  internal LecteurEtat Etat { get; private set; }

  internal LecteurAudio()
  {
    Etat = LecteurEtat.Arrete;
  }

  internal LecteurEtat Action()
  {
    switch (Etat)
    {
      case LecteurEtat.Arrete:
        Etat = LecteurEtat.EnLecture;
        break;

      case LecteurEtat.EnLecture:
        Etat = LecteurEtat.EnPause;
        break;

      case LecteurEtat.EnPause:
        Etat = LecteurEtat.EnLecture;
        break;
    }

    return Etat;
  }
}