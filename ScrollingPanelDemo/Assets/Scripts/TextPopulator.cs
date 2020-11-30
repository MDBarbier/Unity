using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopulator : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In interdum, augue vitae varius scelerisque, ex sem fermentum enim, a vestibulum ante dui fringilla dui. " +
            "Nulla iaculis fermentum libero. Pellentesque lacinia, libero nec vehicula mattis, urna erat tempor erat, ac vestibulum massa mauris non felis. Nunc vel sapien id justo " +
            "consectetur faucibus accumsan at urna. Nullam laoreet vel lorem in eleifend. Suspendisse pretium tellus eu mi tincidunt tincidunt. Nunc ex eros, commodo ut odio et, pellentesque " +
            "cursus nibh. Integer sagittis mi eu arcu ultrices ultricies. Aenean ut metus iaculis, lacinia justo sit amet, fermentum sapien. Quisque in arcu vehicula, pharetra libero ut, " +
            "placerat tellus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur non vestibulum quam, eu consequat erat. Aliquam tristique " +
            "ipsum a dictum vehicula. Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed laoreet tempor neque, nec aliquet augue malesuada sed. Cras facilisis sollicitudin sem, eu " +
            "tincidunt augue elementum at. Etiam nec ornare dolor. In semper orci vitae augue accumsan molestie.Integer dapibus suscipit mattis. In ut purus est. Sed eu porttitor neque. " +
            "Sed vel lorem dignissim, pellentesque augue sed, venenatis nibh. Praesent congue tortor non massa semper placerat.Nulla varius velit in turpis consectetur, sed sagittis orci " +
            "ullamcorper.Quisque consectetur rutrum mi, vitae lacinia mi. Integer a accumsan sem. Vivamus pellentesque convallis massa, ac placerat leo sollicitudin ut. Nullam tempor enim " +
            "a justo volutpat egestas.Aliquam erat volutpat.Sed sollicitudin diam eget pharetra suscipit. Fusce a enim nisi. Sed suscipit posuere nisi, quis fermentum odio feugiat in. Fusce " +
            "lacus justo, auctor vitae odio at, pretium auctor nisl. Suspendisse massa ex, cursus nec nisi non, congue blandit urna. Curabitur feugiat, odio vel convallis convallis, ante " +
            "justo pharetra dolor, quis placerat nibh dui vitae risus.Phasellus suscipit porta eros sit amet feugiat.Donec quis ante quis enim gravida viverra sit amet nec est.Morbi vel " +
            "tempus nisl. Integer ipsum nisi, sodales quis hendrerit vitae, condimentum id sapien. Nulla fringilla sollicitudin leo in congue.Proin ornare vel lectus quis bibendum. Morbi " +
            "vel maximus nunc. Vestibulum ut odio eu nisl luctus posuere. Etiam imperdiet neque nec magna elementum, non porta nisi iaculis.Donec pharetra urna ut odio tincidunt, non sagittis " +
            "magna malesuada.Vivamus vitae nisl ut tortor consequat blandit.Nulla interdum dignissim nibh, sit amet laoreet felis posuere dictum.Pellentesque habitant morbi tristique senectus " +
            "et netus et malesuada fames ac turpis egestas.Vestibulum accumsan mauris lectus, quis fringilla velit tempus imperdiet. Maecenas iaculis bibendum posuere. Integer vehicula porta " +
            "erat, nec aliquet arcu scelerisque sed.Nunc convallis nec enim ut ullamcorper. Nullam ligula orci, tristique at eros at, malesuada iaculis ipsum. Integer tellus tortor, lobortis " +
            "vel risus vitae, lobortis placerat sapien. Vivamus porttitor magna at lorem feugiat aliquam.Proin eget nunc vitae urna posuere semper.Nam rhoncus bibendum laoreet. Nunc mauris " +
            "tellus, vehicula congue efficitur sed, imperdiet quis justo. In hac habitasse platea dictumst.Curabitur hendrerit augue ac condimentum maximus. Etiam eget tortor sit amet orci " +
            "suscipit faucibus id quis ligula.Nulla lacinia quam eu odio euismod auctor.Aenean tristique nisi quis posuere convallis. Etiam at risus hendrerit, tincidunt tortor ut, dapibus " +
            "sem.Curabitur luctus lorem massa, vel mollis lacus malesuada sed. Mauris condimentum odio ex.Aenean imperdiet purus sit amet mauris efficitur rutrum. Interdum et malesuada " +
            "fames ac ante ipsum primis in faucibus.Nullam fringilla metus erat, nec iaculis diam accumsan ut. Integer pharetra vulputate lorem, id egestas nibh. Sed sagittis odio a purus " +
            "pellentesque consectetur.Donec porta dolor vitae ultrices commodo. Morbi dapibus, nisi ultrices finibus semper, ipsum sem auctor massa, ac sollicitudin arcu nulla ac sem.Nam " +
            "vestibulum facilisis magna, quis faucibus mauris molestie dignissim. Nulla fringilla elit in venenatis blandit. Nullam in libero magna. Nunc viverra justo eget nisl consectetur" +
            ", in egestas leo venenatis.Proin et massa magna.Praesent pretium turpis ante, nec tincidunt sapien ornare eget. Mauris sit amet leo sit amet augue mollis tristique sed at " +
            "velit. Donec lobortis urna eu semper aliquet. Etiam mollis consequat nisl at pellentesque. Sed quis gravida turpis. Phasellus euismod tellus ac ornare aliquet. Curabitur " +
            "dignissim nibh ac dignissim molestie.Nam dapibus arcu mollis pellentesque finibus. Aliquam lobortis lacinia erat vitae sodales. Duis quis fringilla augue, a vulputate eros. " +
            "In in interdum eros, vitae molestie nibh. Pellentesque id dapibus metus, ut sodales enim. Mauris suscipit ullamcorper ornare. Nunc vulputate nunc eget risus aliquam, vitae " +
            "congue est mollis.Mauris consectetur ex mauris, vel ullamcorper elit fringilla eu. Nam auctor gravida lacus, non sollicitudin turpis consequat ac.Donec sed ligula et purus " +
            "ultrices sodales.Pellentesque et viverra erat, rhoncus suscipit ligula. Vestibulum vitae dolor rutrum, eleifend diam nec, vestibulum est.Vivamus volutpat velit et orci " +
            "lacinia, a congue dui facilisis.Quisque est quam, luctus id molestie in, condimentum a nisi.Donec elementum ante diam, vitae ultrices sem laoreet et. Phasellus vel luctus " +
            "risus. Vestibulum mattis ultricies ligula, non porta enim facilisis et. Aliquam efficitur ex turpis, sed venenatis felis efficitur ut. Phasellus posuere ac sapien nec blandit." +
            "Donec sodales posuere lectus vitae convallis. Nunc maximus, ante a accumsan sagittis, massa est sodales dolor, eget euismod lacus risus at ex.Proin eget tellus aliquet, " +
            "ultricies dui non, molestie ipsum.Praesent non ante volutpat, molestie enim eu, luctus elit.Nam in leo ante. In ornare diam sit amet maximus commodo.Phasellus varius, purus " +
            "id aliquam malesuada, urna elit consequat odio, id cursus ante arcu at lorem.Vestibulum pellentesque dignissim erat, in posuere enim malesuada et. Phasellus elementum ante " +
            "vel dolor tristique, ut elementum mauris ornare.Vivamus non congue tellus. Aenean bibendum semper leo ac blandit. Mauris tempor tortor vitae massa tincidunt sodales.Vivamus " +
            "ut hendrerit orci. Morbi euismod mauris vel nisi placerat lacinia.Praesent eleifend, nibh ut laoreet interdum, mi ipsum facilisis massa, nec condimentum ipsum tortor congue " +
            "massa.Aenean facilisis diam mauris, id porta felis vulputate a.Interdum et malesuada fames ac ante ipsum primis in faucibus.Sed sed lorem aliquet, commodo sapien id, blandit " +
            "lacus.In dolor velit, rutrum vitae leo eget, imperdiet efficitur felis. Fusce est sem, tincidunt sed ullamcorper in, interdum non arcu.Cras dapibus condimentum pellentesque. " +
            "Nulla blandit faucibus tincidunt. Vestibulum ex metus, euismod egestas felis ac, tempus porttitor augue. Ut mi nibh, semper accumsan semper nec, pharetra quis lacus. " +
            "In hendrerit efficitur erat viverra hendrerit. In porta auctor ante, ac placerat quam eleifend nec. Mauris aliquam tortor vitae egestas rutrum. Nulla pellentesque sollicitudin " +
            "justo, quis eleifend sem molestie vel. In quis posuere metus.Aliquam erat volutpat.In sollicitudin, elit eget ultricies eleifend, leo lorem molestie orci, ac sagittis " +
            "sem lacus ac purus.Suspendisse vestibulum mattis varius. In vel vehicula est. Ut suscipit quis lectus eu venenatis. Donec quis aliquam eros, in dapibus neque. Etiam ultrices " +
            "libero neque, quis fermentum metus tristique vel. Donec eu nisi vitae nunc placerat imperdiet.Aliquam pellentesque metus quis libero congue, quis fermentum erat lobortis." +
            "Aenean orci diam, scelerisque vel odio facilisis, tempor convallis est. Nam sit amet magna nibh.Sed erat est, consequat ac dolor id, gravida condimentum augue. Mauris dapibus " +
            "luctus iaculis.Praesent sit amet bibendum magna.Nam elementum diam sapien, non blandit nisi viverra id. Nullam risus lorem, congue sed mollis sed, bibendum eget lectus. " +
            "Sed id libero libero. Maecenas at dolor lacus. Donec bibendum metus consequat, cursus nisl nec, pharetra sapien.Quisque vitae consequat dolor. Pellentesque vehicula purus " +
            "sed vulputate viverra. Praesent rhoncus velit sed felis gravida ultricies.Vivamus sollicitudin dignissim leo, sed eleifend tortor tempor ac. Etiam vel neque vel est rutrum " +
            "dapibus vitae sit amet ante.Quisque ornare auctor quam sed laoreet.Aenean aliquam justo quis varius sodales. Vestibulum sed tellus sagittis, porttitor urna eget, suscipit" +
            " massa.Curabitur faucibus et nisi id consectetur. Nulla facilisi. Cras euismod euismod ornare. Sed ac arcu nunc. In eget ante odio. Aenean tempor rhoncus dapibus. Proin " +
            "imperdiet, nulla eu finibus aliquam, urna ex aliquet nibh, pharetra pulvinar tellus massa non ante.Sed arcu lacus, gravida a massa non, volutpat feugiat lacus. Curabitur " +
            "interdum venenatis nisl, commodo tincidunt lorem molestie scelerisque.Donec vehicula ex quis erat venenatis, non mollis ligula suscipit.Nullam blandit, neque quis semper " +
            "consectetur, elit tellus sagittis dui, ac commodo mauris mauris bibendum turpis.Integer lacinia, elit et pulvinar ornare, lectus lectus vulputate leo, consequat sagittis " +
            "ante risus nec lacus.Donec non leo at dolor eleifend tempor.Duis consequat bibendum nisl eu malesuada. Etiam enim massa, eleifend et aliquam sed, auctor a metus. In fringilla " +
            "scelerisque tellus nec vulputate. Sed molestie enim eget nisl tristique, eget dignissim libero tincidunt.Fusce ut placerat orci. Suspendisse dapibus volutpat ipsum non dictum." +
            " Integer vestibulum ultrices tellus, eu cursus quam mattis ut. Quisque tincidunt nisl ut condimentum egestas. Suspendisse pharetra massa non tellus commodo pellentesque." +
            "Pellentesque mattis, dui vel vehicula rhoncus, tellus lectus iaculis augue, non pretium ligula ex vitae eros.Vestibulum vel euismod ante. Maecenas venenatis mollis commodo. " +
            "Vestibulum pulvinar elit vel tellus iaculis, id tincidunt felis malesuada.Fusce quis dolor sapien. Nulla fringilla id diam sit amet aliquet.Nam congue tristique elit, vitae " +
            "malesuada orci fringilla a. Morbi luctus quam nisi, ac vehicula eros faucibus ut. Suspendisse sodales lorem interdum elementum malesuada.Duis pharetra, velit vel scelerisque " +
            "gravida, ex lacus dictum urna, ultrices facilisis turpis tortor nec metus.Phasellus a lorem odio. Nulla facilisi. Praesent molestie massa a nulla fringilla venenatis.Ut " +
            "scelerisque, nisl posuere tincidunt imperdiet, purus tellus commodo felis, lobortis aliquet purus erat et odio.Cras congue tristique ante et iaculis. Integer aliquet magna a " +
            "mauris aliquet faucibus.Vestibulum vel odio ante. Praesent sed quam aliquet tellus vulputate fringilla.Curabitur mollis nisl vel enim egestas fermentum.Pellentesque placerat " +
            "felis dignissim tortor efficitur, et feugiat urna aliquam.Praesent mattis est interdum nisl maximus interdum.Suspendisse potenti. Etiam in feugiat lorem. Donec id tempor mi." +
            " Fusce id egestas diam. Ut sodales, lorem nec aliquet aliquet, tellus arcu mollis dolor, in sollicitudin elit urna sit amet tortor. Donec nec tincidunt tortor. Curabitur " +
            "eleifend sapien eu nulla pellentesque ultricies.Maecenas sit amet vestibulum tortor.Sed volutpat, tortor nec tincidunt fermentum, justo orci euismod lorem, nec malesuada " +
            "turpis mi ut orci.Proin laoreet, felis eget cursus molestie, risus dolor ullamcorper odio, at mattis velit justo sit amet massa.Fusce hendrerit ligula ac pretium commodo." +
            " Integer a neque lobortis, imperdiet odio a, ultricies sem.Aliquam tincidunt arcu vestibulum nulla fermentum, a aliquam est lacinia.Cras tristique gravida placerat. " +
            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Suspendisse non condimentum metus. Aenean at erat lorem. Mauris in ante purus. " +
            "Ut dapibus porta commodo. ";    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
