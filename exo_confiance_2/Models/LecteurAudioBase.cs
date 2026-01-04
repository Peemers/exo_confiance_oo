using exo_confiance_2.Enums;

namespace exo_confiance_2.Models;

internal abstract class LecteurAudioBase
{
  protected LecteurEtat Etat { get; set; }

  internal LecteurAudioBase()
  {
    Etat = LecteurEtat.Arrete;
  }

  public abstract ActionResult Play();

  public abstract ActionResult Pause();

  public abstract ActionResult Stop();
}