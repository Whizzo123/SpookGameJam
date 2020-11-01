using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlot : MonoBehaviour
{

    public Material materialToSwitchToWhenSelected;
    public Material materialToSwitchToWhenBlocked;
    public Material defaultMaterial;
    public SkinnedMeshRenderer rendererToEffectPegs;
    public SkinnedMeshRenderer rendererToEffectSign;
    public GameObject buildPosition;
    public GameObject builtGO;
    private bool blocked;
    public Animator animator;
    public bool PlotBlocked
    {
        get
        {
            return blocked;
        }
        set
        {
            blocked = value;
            if(value)
            {
                SwapMaterials(materialToSwitchToWhenBlocked);
            }
            else
            {
                SwapMaterials(defaultMaterial);
            }
        }
    }
    public string builtGOPrefabName;
    public BuildPlot twinBuildPlot;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Switch"))
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if (info.normalizedTime > 1f)
            {
                animator.SetBool("switchFinished", true);
            }
        }
    }

    public void ClickedOn()
    {
        if (PlotBlocked == false)
        {
            SwapMaterials(materialToSwitchToWhenSelected);
            animator.SetTrigger("Selected");
        }
    }

    public void ClickedOff()
    {
        if (PlotBlocked == false)
        {
            SwapMaterials(defaultMaterial);
            animator.SetTrigger("Selected");
        }
    }



    public void BuildOn(GameObject towerGO)
    {
        builtGOPrefabName = towerGO.name;
        builtGO = (GameObject)Instantiate(towerGO, buildPosition.transform.position, Quaternion.identity);
        if(twinBuildPlot != null)
            twinBuildPlot.PlotBlocked = true;
    }

    public void RemoveTower()
    {
        if (builtGO != null)
        {
            if(twinBuildPlot != null)
                twinBuildPlot.PlotBlocked = false;
            Destroy(builtGO);
            builtGO = null;
        }
        
    }

    private void SwapMaterials(Material material)
    {
        Material[] pegMaterials = rendererToEffectPegs.materials;
        pegMaterials[0] = material;
        Material[] signMaterials = rendererToEffectSign.materials;
        signMaterials[0] = material;
        rendererToEffectPegs.materials = pegMaterials;
        rendererToEffectSign.materials = signMaterials;
    }
}
