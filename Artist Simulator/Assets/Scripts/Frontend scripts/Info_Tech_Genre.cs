using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_Tech_Genre : MonoBehaviour
{
    public Image brush;
    public Image tablet;
    public Image spray;
    public Image pencil;

    public Image graffiti;
    public Image stillLife;
    public Image scenery;
    public Image portrait;
    public Image modernArt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        brush.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Techniques.Brush).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Techniques.Brush).MaxXp * 100;
        tablet.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Techniques.GraphicsTablet).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Techniques.GraphicsTablet).MaxXp * 100;
        spray.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Techniques.SprayPaint).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Techniques.SprayPaint).MaxXp * 100;
        pencil.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Techniques.Pencil).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Techniques.Pencil).MaxXp * 100;

        graffiti.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Genres.Graffiti).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Genres.Graffiti).MaxXp * 100;
        stillLife.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Genres.StillLife).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Genres.StillLife).MaxXp * 100;
        scenery.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Genres.Scenery).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Genres.Scenery).MaxXp * 100;
        portrait.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Genres.Portrait).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Genres.Portrait).MaxXp * 100;
        modernArt.fillAmount = Player.ArtSkills.GetSkill(GameConstants.Genres.ModernArt).Xp * 0.01f / Player.ArtSkills.GetSkill(GameConstants.Genres.ModernArt).MaxXp * 100;


    }
}
