namespace exo_confiance_2.Models;

using exo_confiance_2.Enums;

internal class LecteurAudioClassique : LecteurAudioBase
{
  public override ActionResult Play()
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

  public override ActionResult Pause()
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

  public override ActionResult Stop()
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