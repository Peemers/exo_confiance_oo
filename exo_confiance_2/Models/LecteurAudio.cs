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

  internal ActionResult Play()
  {
    switch (Etat)
    {
      case LecteurEtat.Arrete:
        Etat = LecteurEtat.EnLecture;
        return ActionResult.Succes;

      case LecteurEtat.EnLecture:
        return ActionResult.DejaDansCetEtat;

      case LecteurEtat.EnPause:
        Etat = LecteurEtat.EnLecture;
        return ActionResult.Succes;

      default:
        return ActionResult.ActionImpossible;
    }
  }

  internal ActionResult Pause()
  {
    switch (Etat)
    {
      case LecteurEtat.Arrete:
        return ActionResult.ActionImpossible;

      case LecteurEtat.EnLecture:
        Etat = LecteurEtat.EnPause;
        return ActionResult.Succes;

      case LecteurEtat.EnPause:
        return ActionResult.DejaDansCetEtat;

      default:
        return ActionResult.ActionImpossible;
    }
  }

  internal ActionResult Stop()
  {
    switch (Etat)
    {
      case LecteurEtat.EnLecture:
        Etat = LecteurEtat.Arrete;
        return ActionResult.Succes;

      case LecteurEtat.EnPause:
        Etat = LecteurEtat.Arrete;
        return ActionResult.Succes;

      case LecteurEtat.Arrete:
        return ActionResult.DejaDansCetEtat;

      default:
        return ActionResult.ActionImpossible;
    }
  }
}