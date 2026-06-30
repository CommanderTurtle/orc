module ConvertedFiles.Countku.N1Md

let file = """# project db
# This file documents all of the rules and nuances of countku.

<br><a href="https://shel.sh/projects/1.md" title="[logic]">[logic]</a> . <a href="https://shel.sh/projects/2.md" title="[changelog]">[changelog]</a> . <a href="https://shel.sh/projects/3.md" title="[guidebook]">[guidebook]</a><br>

## Part 1, an introductory post by u/CommanderT1562 on Reddit (this is me),

---

https://www.reddit.com/r/haikusbot/comments/1p1aq85/countku_expert_level_counting/

Original Post can be viewed above.

Post Title: Countku, expert level counting

Post Main Content:
Image: An image displaying "countku" in action in a discord server with users getting the "Count" bot and "Haikusbot" to work simultaneously within the same thread.

Image Standalone Link: https://i.redd.it/luz9n53zf82g1.jpeg

Image OCR:

# Count>
..
user Salvatore Guilliano:
19
✅ (Reacted by user counting)

user apple.:
20
✅ (Reacted by user counting)

user Commander Turtle:
21+1.1-1.1+1-1
✅ (Reacted by user counting)

user HaikuBot (App):
> Twenty two, plus one
> point one, minus one point one,
> plus one, minus one
> - commanderturtle

user Commander Turtle:
22+1.1-1.1+1-1
❌ (Reacted by user counting)

user counting (App):
@commanderturtle RUINED IT AT 21!! Next number is **1. You can't count two numbers in a row.**
> Vote [here](Links to external site) to earn saves so you can continue counting next time. See `c !help`.

user Commander Turtle:
(The next correct number is **1**, since I broke it)
Have two bots reply to you, HOW-TO.
Add zeros like such. Post a second reply in plaintext. Delete the plaintext comment. Watch! :pepe emote:

—
1-3.000+1+1+1
✅ (Reacted by user counting)

user HaikuBot (App):
> One minus three point
> zero zero zero, plus
> one, plus one, plus one

user Commander Turtle:
Good bot! Now you guys play the new minigame

(Hint: 2-3.000+1+1+1 *is* **2**)
Then, type it out, delete :hearthands:
💛👀 (Reacted by user Haikubot)

(end of image OCR)

Post Body:

Good bot. Good people. For the betterment of us, I wanted to share.

Haikus must relate to nature, feel me type shit. Numbers are nature.

I figured I’d want to put this out completely for our enjoyment…

**Impress your friends with countku,**

a base ten number system more convoluted than all prime numbers

**Have fun brothers**

If modifying countku, please credit the thought experiment to me,

commander turtle. Really appreciate it, it’s all I can ask.

I don’t intend to monetize it in any way, so if you sell countku or a variation or translation, I just ask for a 1 satoshi per api call as royalty per the O’ Leary license, thanks luv you.

You can wrap the shaves of pennies in envelopes and mail them to me!

Cheats:

This can be expanded upon by making an entire number system that factors in syllabic count… here are some cheats: one can apply “type shit” or other two syllabic memes to finish a haiku—one can adjust zero to be “Oh” or “Zed” for fun, or ragebait—decimal is always “point”, it’s proper—lastly, it gets increasingly difficult as the twenties and seventies for example have very different available options, I encourage everyone to make it as fair as possible. I set the world record last night at twenty one, but my ‘edited and deleted’ message when testing only bot-replied to me on my twenty two test, although the count was correct. Fair warning not to cut off an individual Ku midway through a zero, one point zero ze-ro is NOT an endKu-startKu, since a word must be finished at the end of a Ku, cheating with “one point zero Oh” is NOT fun, since it circumvents the memory olympics of sticking to your initial guns

(end of post)

---

## Part 2, The goal of countku

Countku does not have very many specific rules, other than the nuance that English syllabic count and intended structure is VERY specific. Given all nuance of english and syllables, refer to the following Rulebook, which contains a Complete Database of Every Part of Countku. This Part of Introduction.md will be solely for maintaining structure of how Countku math should work.

### Data Matricies:

#### Table 1: Substrings-All

| Index | Substring | AddSyl | IsBase | IsScale | IsMathOp | IsPrep | IsPassv | Pre_A | Pre_The | Pro_Of | Base Words & Notes |
|-------|-----------|--------|--------|---------|----------|--------|---------|-------|---------|--------|-----------------------------------------------|
| a00 | one       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 1 |
| a01 | two       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 2 |
| a02 | three     | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 3 |
| a03 | four      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 4 |
| a04 | five      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 5 |
| a05 | six       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 6 |
| a06 | seven     | 2      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 7 |
| a07 | eight     | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 8 |
| a08 | nine      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 9 |
| a09 | ten       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 10 |
| a10 | eleven    | 3      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 11 |
| a11 | twel      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 12 |
| a12 | ve        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (twel-ve) silent 'e' natively counted here. |
| a13 | fth       | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (twel-fth, fi-fth) fraction builder. |
| a14 | thir      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (thir-teen, thir-ty, thir-d) |
| a15 | fi        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (fi-fth, fi-fty, fi-fteen) |
| a16 | eigh      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (eigh-teen, eigh-ty) |
| a17 | teen      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base builder +10 |
| a18 | twen      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (twen-ty) |
| a19 | ty        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base builder *10 |
| a20 | tie       | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math ordinal divisor builder (twentie, thirtie) |
| a21 | ry        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (senary, undenary) string terminator |
| a22 | log       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Natural or Base logarithm |
| a23 | arithm    | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Log-arithm string target |
| a24 | zed       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 0 |
| a25 | ze        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 0 (ze-ro) |
| a26 | ro        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 0 (ze-ro) |
| a27 | with      | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Preceeds prepositional func targets |
| a28 | from      | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Preceeds subtract targets |
| a29 | the       | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Grammar trigger / func prefix |
| a30 | and       | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Math arrays & digit-linker |
| a31 | of        | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Proceeding-of flag trigger |
| a32 | by        | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Proceeding-by flag trigger |
| a33 | to        | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Exp flag trigger (to the power of) |
| a34 | a         | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Func prefix/Fraction initiator |
| a35 | divid     | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Div operator |
| a36 | ing       | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Active participle (passive builder target) |
| a37 | ed        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Past participle terminator (divid-ed) silent e |
| a38 | multipl   | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Mult operator |
| a39 | ied       | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | (multipl-ied) Passive terminator |
| a40 | ying      | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | (multipl-ying) Active participle |
| a41 | point     | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Floating point dot trigger |
| a42 | plus      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Add operator |
| a43 | add       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Add operator base |
| a44 | i         | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Inner word linker |
| a45 | tion      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Structural Noun (addi-tion) |
| a46 | minus     | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Sub operator |
| a47 | subtract  | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Sub operator base |
| a48 | root      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Requires "the", outputs Math.pow(x, 1/n) |
| a49 | al        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (radic-al, tetragon-al) terminator |
| a50 | squar     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | (squar-e) base |
| a51 | e         | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Silent functional 'e' terminator |
| a52 | cub       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math.cbrt(x) |
| a53 | ic        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Root terminator |
| a54 | rad       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Radical root operator |
| a55 | half      | 1      | 0      | 0       | 1        | 0      | 0       | 1     | 0       | 1      | Fractional operator / divisor |
| a56 | halv      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | (halv-ed) Divisor base |
| a57 | rst       | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (fi-rst) ordinal flag |
| a58 | th        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Ordinal math trigger flag |
| a59 | d         | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (thir-d, square-d) suffix logic |
| a60 | at        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Syllable noise |
| a61 | ad        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | (qu-ad, ad-d) |
| a62 | tetr      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 map (tetradic) |
| a63 | tessar    | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 map |
| a64 | agonal    | 3      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Shape math suffix |
| a65 | ant       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a66 | quart     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 suffix map |
| a67 | quadr     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 string |
| a68 | bi        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math multiplier/flag (x2) |
| a69 | nt        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (tange-nt) silent end suffix |
| a70 | qui       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 5 string |
| a71 | na        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base string |
| a72 | penta     | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 5 string |
| a73 | gon       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a74 | sex       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 6 string |
| a75 | tic       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a76 | se        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base string |
| a77 | hex       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 6 string |
| a78 | hep       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 7 string |
| a79 | oc        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 8 string |
| a80 | non       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 9 string |
| a81 | en        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 9 target |
| a82 | ne        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | String target |
| a83 | dic       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Target term |
| a84 | dec       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 10 term |
| a85 | un        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 11 builder |
| a86 | hen       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 11 builder |
| a87 | du        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 12 target |
| a88 | do        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 12 builder |
| a89 | doub      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Mult (x2) base |
| a90 | le        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a91 | times     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Mult op |
| a92 | less      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Sub op |
| a93 | pow       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 0      | Power initiator |
| a94 | er        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a95 | base      | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Log structural requirement |
| a96 | con       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Linker |
| a97 | sin       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Trig Math.sin |
| a98 | co        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Trig Map |
| a99 | tan       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Trig Math.tan |
| a100| gent      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (tan-gent) target |
| a101| cant      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (co-se-cant) |
| a102| nat       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Natural log prefix map |
| a103| ur        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base Linker |
| a104| in        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Invert flag Math(1/x) |
| a105| vers      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (in-vers-e) map |
| a106| us        | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Passive flag base |
| a107| hund      | 1      | 0      | 1       | 0        | 0      | 0       | 1     | 0       | 0      | Hundred target |
| a108| red       | 1      | 0      | 1       | 0        | 0      | 0       | 0     | 0       | 0      | Base builder |
| a109| thou      | 1      | 0      | 1       | 0        | 0      | 0       | 1     | 0       | 0      | Thousand target |
| a110| sand      | 1      | 0      | 1       | 0        | 0      | 0       | 0     | 0       | 0      | Builder |
| a111| mil       | 1      | 0      | 1       | 0        | 0      | 0       | 1     | 0       | 0      | Million target |
| a112| lion      | 1      | 0      | 1       | 0        | 0      | 0       | 0     | 0       | 0      | Builder |
| a113| der       | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Preposition linker target |
| a114| go        | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Passive map target |
| a115| flu       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Lexicon target |
| a116| ence      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Lexicon terminator |
| a117| ca        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Substr map |
| a118| di        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Div string |
| a119| vi        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Div substr |
| a120| sion      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Op noun |
| a121| ion       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Op noun target |
| a122| sep       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Ordinal (septenary) base |
| a123| den       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Ordinal (denary) map |
| a124| duo       | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math prefix (duodenary) |
| a125| ta        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Ordinal (pen-ta-gon-al) |

Square root: Math.sqrt(x) is a shortcut for Math.pow(x, 0.5).
Cube root: Math.cbrt(x) is a shortcut for Math.pow(x, 1/3).

#### Table 2: Base Glossary

| Index            | Range                                                                          | Note (if any)                                                            |
|------------------|--------------------------------------------------------------------------------|--------------------------------------------------------------------------|
| Zero             | 0                                                                              | Zed or Zero                                                              |
| Decimal-Place    | .                                                                              | The decimal point itself. Continuous trailing $BaseNums till next ()func |
| Non-Whole        | 0-1                                                                            | Physically, the same as $BaseNum's, following the word "point"           |
| BaseNum          | 1-9                                                                            |                                                                          |
| Ten              | 10                                                                             | One point ten doesn't need to throw an error, but it's == one point one  |
| Eleven           | 11                                                                             | The only three syllable , whole number , between 0-20                    |
| Twelve           | 12                                                                             | The only one syllable , whole number , technically in the "teens" range  |
| Teens            | 1{3-9}; 13-19                                                                  | thir,four,fif,six,seven,eigh,nine -teen (4,6,7,9 are $BaseNum-teen)      |
| Twentie != Twenty| n/a                                                                            | `Twentie` (with 'th' mapping) is a descriptor/divisor, strictly != `Twenty` |
| Tens             | {2-9}0; 20,30,40,50,...,90                                                     | twen,thir,four,fif,six,seven,eigh,nine -ty (4,6,7,9 are $BaseNum-ty)     |
| Tens-OneVals     | {2-9}{1-9}; 21-29, 31-39, 41-49,...,91-99                                      | Full $Tens-Codex with following $BaseNum. (Ex. Twenty Two)               |
| A Hundred        | 100                                                                            | "A hundred" mathematically identical to "One hundred". Native mapping.   |
| Hundreds         | {1-9}00; 100, 200, 300, 400,...,900                                            | $BaseNum alone, with following "hundred"                                 |
| Hundreds-Ten     | {1-9}10; 110, 210, 310, 410,...,910                                            | $BaseNum,"hundred",[optional and],"ten"                                  |
| Hundreds-Eleven  | {1-9}11; 111, 211, 311, 411,...,911                                            | $BaseNum,"hundred",[optional and],"eleven"                               |
| A Thousand       | 1000                                                                           | "A thousand" mathematically identical to "One thousand".                 |
| Thousands +      | (All have applied rules from lowers)                                           | $BaseNum,[optional thousands zone]"thousand", [optional hundreds zone]   |
| Irrationals      | pi, e, a lot of roots, quite a lot of trig, log, and power function outputs    | Set $Ir, bool, to true (1). (This is so no one runs 'pi point zero', etc)|
| Highers          | 1000000,1000000000,1000000000000,1000000000000000,...+3 zeroes for each range. | million,billion,trillion,quadrillion,...,duodecillion(12)                | 

....1,234,567,891,011,121,314,151,617,181,920,212,223,240 (final level, lol)

- Note the "tens" "and" nuance. 
- I.e. One hundred _and_ ten thousand, eight hundred _and_ fourty two   — Set $AndMatrix=11
- See: One hundred ten thousand, eight hundred forty two                — Set $AndMatrix=00
- Third: One hundred eighty five million, six hundred and eighty eight thousand, for hundred and sixty four — Set $AndMatrix=011
- Finally: One hundred ninety seven septillion, eight hundred and fourty eight sextillion, six hundred and ninety three pentillion, six hundred and seventy three quadrillion, four hundred and ninety nine trillion, fifty billion, three million, and thirty three thousand.
	> This would have an $AndMatrix of 011110010
- The Matrix might seem redundent, until you realize how much data it can hold. From this value, we know:
1. n-2 Length of the matrix = 7 *See, Septillion.
2. The user used 'ands' in the sextillions, the pentillions, the quadrillions, the trillions, the thousands.
3. There *must* be nonzero values for *something* ten-and-under related **in these particular, relative n Zones**.
4. It's just good data to have.
- Lock-in logic: "One hundred and two" triggers a rule that you can never future-on say "One hundred two" because you locked in to "and" variant for the hundredths place formatting.

#### Table 3: Full-Operators-All Matrix (Math & Lexical Engine Map)

*NOTE ON OPTIONAL 'NOISE' TOKENS*: The arrays defined in `$P00_Noise` in Table 4 can legally manifest BEFORE, AFTER, or BETWEEN any of the target variables in `d25-d29`. They grant free syllable buffering and execute NO mathematical changes. 
*Programmatic handling:* `JS.replace($P00_Noise, '')` before executing operation chains.

| Index | Lexical Math String Map | Math Output | Is_()f() | Is_f()() | Is_f() | Is_()f | IsPassv | ReqDelim | Pre:A | Pre:The | Lexical Node Assignments | Note/Title |
|-------|-------------------------|-------------|----------|----------|--------|--------|---------|----------|-------|---------|--------------------------|------------|
| d00 | $A $a42 $B | A + B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | None | A plus B |
| d01 | $A $a46 $B | A - B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | None | A minus B |
| d02 | $A $a91 $B | A * B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | None | A times B |
| d03 | $a43 $A $a33 $B | A + B | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | $a33 (to) | Add A to B |
| d04 | $a47 $A $a28 $B | B - A | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | $a28 (from) | Subtract A from B |
| d05 | [$a34/$a00] $cNum $a31 $A | Math.pow(A, 1/C) | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | $a31 (of) | A/One [Fraction] of A |
| d06 | [$a29] $a50 $a48 $a31 $A | Math.sqrt(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] square root of A |
| d07 | [$a29] $a52 $a48 $a31 $A | Math.cbrt(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cube root of A |
| d08 | [$a29] $cNum $a48 $a31 $A | Math.pow(A, 1/C) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] Nth root of A |
| d09 | [$a29] $a104 $a105 $a51 $a31 $A | 1 / A | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] inverse of A |
| d10 | [$a29] $a97 $a51 $a31 $A | Math.sin(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] sine of A |
| d11 | [$a29] $a98 $a97 $a51 $a31 $A | Math.cos(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cosine of A |
| d12 | [$a29] $a99 $a100 $a31 $A | Math.tan(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] tangent of A |
| d13 | [$a29] $a76 $a101 $a31 $A | 1 / Math.cos(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] secant of A |
| d14 | [$a29] $a98 $a76 $a101 $a31 $A| 1 / Math.sin(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cosecant of A |
| d15 | [$a29] $a98 $a99 $a100 $a31 $A| 1 / Math.tan(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cotangent of A |
| d16 | [$a29] $a102 $a103 $a22 $a31 $A| Math.log(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] natural log of A |
| d17 | $A $a33 [$a29] $a102 $a103 $a22 $a31 $B | Math.pow(A, Math.log(B)) | 0 | 1 | 0 | 1 | 0 | 1 | 0 | 1 | $a31 (of) | A to [the] natural log of B |
| d18 | [$a29] $a22 $a31 $A $a95 $B | Math.log(A)/Math.log(B) | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 | $a31 (of), $a95 (base) | [The] log of A base B |
| d19 | $A $a33 [$a29] $a22 $a31 $B $a95 $C | Math.pow(A, log_c(B)) | 0 | 1 | 0 | 1 | 0 | 1 | 0 | 1 | $a31, $a95 | A to [the] log of B base C |
| d20 | [$a29] $cNum $a22 [$a23] $a31 $A | Math.log(A) / Math.log(C) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $cNum, $a31 (of) | [The] Nth logarithm of A |
| d21 | $A $a33 [$a29] $cNum $a93 $a94 | Math.pow(A, C) | 0 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | None | A to [the] Nth power |
| d22 | $A $a50 $a37 | Math.pow(A, 2) | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A squared |
| d23 | $A $a52 $a37 | Math.pow(A, 3) | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A cubed |
| d25 | $A [$P_Action/$P_Passiv] [$a29] $N_Add $B | A + B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Add | A [using/under] [the] addition to/with/of B |
| d26 | $A [$P_Action/$P_Passiv] [$a29] $N_Sub_Norm $B | A - B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Sub_Norm | A [using/under] [the] subtraction of/with/by B |
| d27 | $A [$P_Action/$P_Passiv] [$a29] $N_Sub_Flip $B | B - A | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Sub_Flip | A [using/under] [the] subtraction from B |
| d28 | $A [$P_Action/$P_Passiv] [$a29] $N_Mul $B| A * B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Mul | A [using/under] [the] multiplication of/by/with B |
| d29 | $A [$P_Action/$P_Passiv] [$a29] $N_Div $B| A / B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Div | A [using/under] [the] division of/by/with/from B |
| d40 | [$a29] $a55 $a31 $A | Math.pow(A, 0.5) OR A/2 | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] Half of A |
| d41 | $A $a56 $a37 | A / 2 | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A halved |
| d42 | $A [$P_Passiv] $a56 $a36 | A / 2 | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 0 | $P_Passiv | A [undergoing] halving |
| d43 | $a89 $a90 $A | A * 2 | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | None | Double A |
| d44 | $A $a89 $a90 $a59 | A * 2 | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A doubled |
| d45 | $A [$P_Passiv] $a89 $a91 | A * 2 | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 0 | $P_Passiv | A [undergoing] doubling |


#### Table 4: Prepositional & Auxiliary Combinations Matrix (Lexical Grammar Variables)

| Variable Block | Expected Phrasing & Words Mapped | Mathematical Engine Purpose / JS Resolution Logic |
|----------------|----------------------------------|---------------------------------------------------|
| `$P00_Noise` | "the influence of", "a total of", "an effect of", etc. | Optional padding logic flag. Pure filler variables used by users to complete syllable counts legally. Safe to execute JS stripping logic upon match before deeper operational evaluation occurs. |
| `$P_Action` | "using", "with", "by", "using with", "with using" | Sets operator mode mapping to true `func()`. Connects previous target base logically into following functional noun mapping blocks. |
| `$P_Passiv` | "undergoing", "under", "with undergoing", "undergoing with" | Same core connective state as `$P_Action`, but flags structural linguistic flow passively. Tells JS that user noun target is having an operation placed *upon* them logically. |
| `$N_Add` | "addition", "addition to", "addition with", "addition of" | Strict Lexical mapped operational execution combinations terminating into basic Math (A + B). Resolves logic mapped from table $a43, $a44, $a45 ("add-i-tion"). |
| `$N_Sub_Norm` | "subtraction", "subtraction with", "subtraction of", "subtraction by" | Noun combination base. Forward Math Execution mapping (A - B) from substrings ($a47, $a121). |
| `$N_Sub_Flip` | "subtraction from" | Flipped operator mapping logic mapped heavily around string component "from". Math logic strictly executes inversely for inputs mapping (B - A). |
| `$N_Mul` | "multiplication", "multiplication with", "multiplication by", "multiplication of" | Combination chunking execution parameters. Base math executes straight input chain mapped logic structure (A * B). |
| `$N_Div` | "division", "division with", "division by", "division of", "division from" | Resolves any trailing grammar strings on execution map. Follows forward functional state math (A / B) natively mapping ($a118, $a119, $a120). Includes 'from' as forward function explicitly by lexical grammar structure default here rather than in `$N_Sub_Flip`. |


#### Table 5: Modifier & Ordinal Definition Matrix ($cNum Mapping Variables)

This defines every legal programmatic variable that maps natively to numerical `$cNum` constants required in fractions, roots, power modifiers, and logarithm bases throughout Table 3.

| `$cNum` Output | Standard Ordinal / Base Strings | Systematic / Latin / Greek Roots | Archaic / Obscure Terminologies | Exact Mapped Substring Target Links |
|----------------|---------------------------------|----------------------------------|---------------------------------|-------------------------------------|
| `0`  | Zeroth | N/A | N/A | `[a24,a58]`, `[a25,a26,a58]` |
| `1`  | First | N/A | N/A | `[a15,a57]` |
| `2`  | Second, Half | Quadratic, Square | N/A | `[a76,a96]`, `[a55]`, `[a67,a60,a53]`, `[a50]` |
| `3`  | Third | Cubic | N/A | `[a14]`, `[a52,a53]` |
| `4`  | Fourth | Quartic, Quadrantal, Tetragonal | Tetradic, Tessaric | `[a03,a58]`, `[a66,a53]`, `[a67,a65,a49]`, `[a62,a64]` |
| `5`  | Fifth | Quintic, Quinary, Pentagonal | Pentadic | `[a15]`, `[a70,a69,a53]`, `[a72,a64]` |
| `6`  | Sixth | Sextic, Senary, Hexagonal | Hexadic, Sextantal | `[a05,a58]`, `[a74,a75]`, `[a77,a64]` |
| `7`  | Seventh | Septic, Septenary, Heptagonal | Heptadic | `[a06,a58]`, `[a122,a75]`, `[a122,a10,a71,a21]`, `[a78,a64]` |
| `8`  | Eighth | Octic, Octonary, Octagonal | Octadic | `[a07,a58]`, `[a79,a75]`, `[a126,a64]` |
| `9`  | Ninth | Nonic, Nonary | Enneadic | `[a08,a58]`, `[a80,a53]`, `[a81,a82,a34,a83]` |
| `10` | Tenth | Decic, Denary | Decadic | `[a09,a58]`, `[a84,a53]`, `[a123,a34,a21]`, `[a84,a34,a83]` |
| `11` | Eleventh | Undecic, Undenary | Hendecadic, Hendecagonal, Undecagonal | `[a10,a58]`, `[a85,a84,a53]`, `[a85,a123,a34,a21]`, `[a86,a84,a64]` |
| `12` | Twelfth | Duodecic, Duodenary, Dodecagonal | Dodecadic, Duodecagonal | `[a11,a13]`, `[a87,a84,a53]`, `[a124,a123,a34,a21]`, `[a88,a84,a34,a83]` |


----------------------------------------------------------------------------------------------------------------------------------------------------------------

*rewrite*


# This file documents all of the rules and nuances of countku.

## Part 1, an introductory post by u/CommanderT1562 on Reddit (this is me),

---

https://www.reddit.com/r/haikusbot/comments/1p1aq85/countku_expert_level_counting/

Original Post can be viewed above.

Post Title: Countku, expert level counting

Post Main Content:
Image: An image displaying "countku" in action in a discord server with users getting the "Count" bot and "Haikusbot" to work simultaneously within the same thread.

Image Standalone Link: https://i.redd.it/luz9n53zf82g1.jpeg

Image OCR:

# Count>
..
user Salvatore Guilliano:
19
✅ (Reacted by user counting)

user apple.:
20
✅ (Reacted by user counting)

user Commander Turtle:
21+1.1-1.1+1-1
✅ (Reacted by user counting)

user HaikuBot (App):
> Twenty two, plus one
> point one, minus one point one,
> plus one, minus one
> - commanderturtle

user Commander Turtle:
22+1.1-1.1+1-1
❌ (Reacted by user counting)

user counting (App):
@commanderturtle RUINED IT AT 21!! Next number is **1. You can't count two numbers in a row.**
> Vote [here](Links to external site) to earn saves so you can continue counting next time. See `c !help`.

user Commander Turtle:
(The next correct number is **1**, since I broke it)
Have two bots reply to you, HOW-TO.
Add zeros like such. Post a second reply in plaintext. Delete the plaintext comment. Watch! :pepe emote:

—
1-3.000+1+1+1
✅ (Reacted by user counting)

user HaikuBot (App):
> One minus three point
> zero zero zero, plus
> one, plus one, plus one

user Commander Turtle:
Good bot! Now you guys play the new minigame

(Hint: 2-3.000+1+1+1 *is* **2**)
Then, type it out, delete :hearthands:
💛👀 (Reacted by user Haikubot)

(end of image OCR)

Post Body:

Good bot. Good people. For the betterment of us, I wanted to share.

Haikus must relate to nature, feel me type shit. Numbers are nature.

I figured I’d want to put this out completely for our enjoyment…

**Impress your friends with countku,**

a base ten number system more convoluted than all prime numbers

**Have fun brothers**

If modifying countku, please credit the thought experiment to me,

commander turtle. Really appreciate it, it’s all I can ask.

I don’t intend to monetize it in any way, so if you sell countku or a variation or translation, I just ask for a 1 satoshi per api call as royalty per the O’ Leary license, thanks luv you.

You can wrap the shaves of pennies in envelopes and mail them to me!

Cheats:

This can be expanded upon by making an entire number system that factors in syllabic count… here are some cheats: one can apply “type shit” or other two syllabic memes to finish a haiku—one can adjust zero to be “Oh” or “Zed” for fun, or ragebait—decimal is always “point”, it’s proper—lastly, it gets increasingly difficult as the twenties and seventies for example have very different available options, I encourage everyone to make it as fair as possible. I set the world record last night at twenty one, but my ‘edited and deleted’ message when testing only bot-replied to me on my twenty two test, although the count was correct. Fair warning not to cut off an individual Ku midway through a zero, one point zero ze-ro is NOT an endKu-startKu, since a word must be finished at the end of a Ku, cheating with “one point zero Oh” is NOT fun, since it circumvents the memory olympics of sticking to your initial guns

(end of post)

---

## Part 2, The goal of countku

Countku does not have very many specific rules, other than the nuance that English syllabic count and intended structure is VERY specific. Given all nuance of english and syllables, refer to the following Rulebook, which contains a Complete Database of Every Part of Countku. This Part of Introduction.md will be solely for maintaining structure of how Countku math should work.

### Data Matricies:

#### Table 1: Substrings-All

| Index | Substring | AddSyl | IsBase | IsScale | IsMathOp | IsPrep | IsPassv | Pre_A | Pre_The | Pro_Of | Base Words & Notes |
|-------|-----------|--------|--------|---------|----------|--------|---------|-------|---------|--------|-----------------------------------------------|
| a00 | one       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 1 |
| a01 | two       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 2 |
| a02 | three     | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 3 |
| a03 | four      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 4 |
| a04 | five      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 5 |
| a05 | six       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 6 |
| a06 | seven     | 2      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 7 |
| a07 | eight     | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 8 |
| a08 | nine      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 9 |
| a09 | ten       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 10 |
| a10 | eleven    | 3      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 11 |
| a11 | twel      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 12 |
| a12 | ve        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (twel-ve) silent 'e' natively counted here. |
| a13 | fth       | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (twel-fth, fi-fth) fraction builder. |
| a14 | thir      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (thir-teen, thir-ty, thir-d) |
| a15 | fi        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (fi-fth, fi-fty, fi-fteen) |
| a16 | eigh      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (eigh-teen, eigh-ty) |
| a17 | teen      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base builder +10 |
| a18 | twen      | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (twen-ty) |
| a19 | ty        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base builder *10 |
| a20 | tie       | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math ordinal divisor builder (twentie, thirtie) |
| a21 | ry        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (senary, undenary) string terminator |
| a22 | log       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Natural or Base logarithm |
| a23 | arithm    | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Log-arithm string target |
| a24 | zed       | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 0 |
| a25 | ze        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 0 (ze-ro) |
| a26 | ro        | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | 0 (ze-ro) |
| a27 | with      | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Preceeds prepositional func targets |
| a28 | from      | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Preceeds subtract targets |
| a29 | the       | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Grammar trigger / func prefix |
| a30 | and       | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Math arrays & digit-linker |
| a31 | of        | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Proceeding-of flag trigger |
| a32 | by        | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Proceeding-by flag trigger |
| a33 | to        | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Exp flag trigger (to the power of) |
| a34 | a         | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Func prefix/Fraction initiator |
| a35 | divid     | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Div operator |
| a36 | ing       | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Active participle (passive builder target) |
| a37 | ed        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Past participle terminator (divid-ed) silent e |
| a38 | multipl   | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Mult operator |
| a39 | ied       | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | (multipl-ied) Passive terminator |
| a40 | ying      | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | (multipl-ying) Active participle |
| a41 | point     | 1      | 1      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Floating point dot trigger |
| a42 | plus      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Add operator |
| a43 | add       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Add operator base |
| a44 | i         | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Inner word linker |
| a45 | tion      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Structural Noun (addi-tion) |
| a46 | minus     | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Sub operator |
| a47 | subtract  | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Sub operator base |
| a48 | root      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Requires "the", outputs Math.pow(x, 1/n) |
| a49 | al        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (radic-al, tetragon-al) terminator |
| a50 | squar     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | (squar-e) base |
| a51 | e         | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Silent functional 'e' terminator |
| a52 | cub       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math.cbrt(x) |
| a53 | ic        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Root terminator |
| a54 | rad       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Radical root operator |
| a55 | half      | 1      | 0      | 0       | 1        | 0      | 0       | 1     | 0       | 1      | Fractional operator / divisor |
| a56 | halv      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | (halv-ed) Divisor base |
| a57 | rst       | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (fi-rst) ordinal flag |
| a58 | th        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Ordinal math trigger flag |
| a59 | d         | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (thir-d, square-d) suffix logic |
| a60 | at        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Syllable noise |
| a61 | ad        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | (qu-ad, ad-d) |
| a62 | tetr      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 map (tetradic) |
| a63 | tessar    | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 map |
| a64 | agonal    | 3      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Shape math suffix |
| a65 | ant       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a66 | quart     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 suffix map |
| a67 | quadr     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 4 string |
| a68 | bi        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math multiplier/flag (x2) |
| a69 | nt        | 0      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (tange-nt) silent end suffix |
| a70 | qui       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 5 string |
| a71 | na        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base string |
| a72 | penta     | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 5 string |
| a73 | gon       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a74 | sex       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 6 string |
| a75 | tic       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a76 | se        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base string |
| a77 | hex       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 6 string |
| a78 | hep       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 7 string |
| a79 | oc        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 8 string |
| a80 | non       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 9 string |
| a81 | en        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 9 target |
| a82 | ne        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | String target |
| a83 | dic       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Target term |
| a84 | dec       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 10 term |
| a85 | un        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 11 builder |
| a86 | hen       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 11 builder |
| a87 | du        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 12 target |
| a88 | do        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Base 12 builder |
| a89 | doub      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Mult (x2) base |
| a90 | le        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a91 | times     | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Mult op |
| a92 | less      | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Sub op |
| a93 | pow       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 0      | Power initiator |
| a94 | er        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Suffix |
| a95 | base      | 1      | 0      | 0       | 0        | 1      | 0       | 0     | 0       | 0      | Log structural requirement |
| a96 | con       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Linker |
| a97 | sin       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Trig Math.sin |
| a98 | co        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Trig Map |
| a99 | tan       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Trig Math.tan |
| a100| gent      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (tan-gent) target |
| a101| cant      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (co-se-cant) |
| a102| nat       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Natural log prefix map |
| a103| ur        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Base Linker |
| a104| in        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 1       | 1      | Invert flag Math(1/x) |
| a105| vers      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | (in-vers-e) map |
| a106| us        | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Passive flag base |
| a107| hund      | 1      | 0      | 1       | 0        | 0      | 0       | 1     | 0       | 0      | Hundred target |
| a108| red       | 1      | 0      | 1       | 0        | 0      | 0       | 0     | 0       | 0      | Base builder |
| a109| thou      | 1      | 0      | 1       | 0        | 0      | 0       | 1     | 0       | 0      | Thousand target |
| a110| sand      | 1      | 0      | 1       | 0        | 0      | 0       | 0     | 0       | 0      | Builder |
| a111| mil       | 1      | 0      | 1       | 0        | 0      | 0       | 1     | 0       | 0      | Million target |
| a112| lion      | 1      | 0      | 1       | 0        | 0      | 0       | 0     | 0       | 0      | Builder |
| a113| der       | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Preposition linker target |
| a114| go        | 1      | 0      | 0       | 0        | 0      | 1       | 0     | 0       | 0      | Passive map target |
| a115| flu       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Lexicon target |
| a116| ence      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Lexicon terminator |
| a117| ca        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Substr map |
| a118| di        | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Div string |
| a119| vi        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Div substr |
| a120| sion      | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Op noun |
| a121| ion       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Op noun target |
| a122| sep       | 1      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Ordinal (septenary) base |
| a123| den       | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Ordinal (denary) map |
| a124| duo       | 2      | 0      | 0       | 1        | 0      | 0       | 0     | 0       | 0      | Math prefix (duodenary) |
| a125| ta        | 1      | 0      | 0       | 0        | 0      | 0       | 0     | 0       | 0      | Ordinal (pen-ta-gon-al) |
| a126| oh        | 1      | special case. Can be used behind decimal "one point oh oh five" == "one point zero zero five". Doesn't work with any functions, or typical Table-6 ruling "absolutely"
| a127| type shit | 2      | special case. "BS" word that is negated in all js math but adds to syllable count.


#### Table 2: Base Glossary

| Index            | Range                                                                          | Note (if any)                                                            |
|------------------|--------------------------------------------------------------------------------|--------------------------------------------------------------------------|
| Zero             | 0                                                                              | Zed or Zero. Syllable count applies uniquely per user choice.            |
| Decimal-Place    | .                                                                              | Maps exclusively from "point". Forces engine into `Parse_State_Float`.   |
| BaseNum          | 1-9                                                                            | Direct value digits.                                                     |
| Ten              | 10                                                                             | Treated as BaseNum internally. ("point ten" executes natively as "point one zero"). |
| Eleven           | 11                                                                             | The only three syllable, whole number between 0-20.                      |
| Twelve           | 12                                                                             | The only one syllable, whole number technically in the "teens" range.    |
| Teens            | 1{3-9}; 13-19                                                                  | thir,four,fif,six,seven,eigh,nine -teen (4,6,7,9 are $BaseNum-teen)      |
| Twentie != Twenty| n/a                                                                            | `Twentie` (with 'th' mapping) is an ordinal divisor, strictly != `Twenty`|
| Tens             | {2-9}0; 20,30,40,50,...,90                                                     | twen,thir,four,fif,six,seven,eigh,nine -ty (4,6,7,9 are $BaseNum-ty)     |
| A Hundred        | 100                                                                            | "A hundred" is mathematically equivalent to "One hundred".               |
| Hundreds         | {1-9}00; 100, 200, 300, 400,...,900                                            | $BaseNum alone, with following "hundred".                                |
| Highers          | 1000, 1000000, 1000000000...                                                   | thousands, millions, billions, trillions, duodecillions(12 zeroes).      | 
| Irrationals      | pi, e, trig, log functions                                                     | Set boolean `$Ir = 1`. Engine natively protects integer checks here.     |


#### Table 3: Full-Operators-All Matrix (Math & Lexical Engine Map)

*NOTE ON OPTIONAL 'NOISE' TOKENS*: The arrays defined in `$P00_Noise` in Table 4 can legally manifest BEFORE, AFTER, or BETWEEN any of the target variables in `d25-d29`. They grant free syllable buffering and execute NO mathematical changes. 
*Programmatic handling:* `JS.replace($P00_Noise, '')` before executing operation chains.

| Index | Lexical Math String Map | Math Output | Is_()f() | Is_f()() | Is_f() | Is_()f | IsPassv | ReqDelim | Pre:A | Pre:The | Lexical Node Assignments | Note/Title |
|-------|-------------------------|-------------|----------|----------|--------|--------|---------|----------|-------|---------|--------------------------|------------|
| d00 | $A $a42 $B | A + B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | None | A plus B |
| d01 | $A $a46 $B | A - B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | None | A minus B |
| d02 | $A $a91 $B | A * B | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | None | A times B |
| d03 | $a43 $A $a33 $B | A + B | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | $a33 (to) | Add A to B |
| d04 | $a47 $A $a28 $B | B - A | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | $a28 (from) | Subtract A from B |
| d05 | [$a34/$a00] $cNum $a31 $A | Math.pow(A, 1/C) | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | $a31 (of) | A/One [Fraction] of A |
| d06 | [$a29] $a50 $a48 $a31 $A | Math.sqrt(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] square root of A |
| d07 | [$a29] $a52 $a48 $a31 $A | Math.cbrt(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cube root of A |
| d08 | [$a29] $cNum $a48 $a31 $A | Math.pow(A, 1/C) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] Nth root of A |
| d09 | [$a29] $a104 $a105 $a51 $a31 $A | 1 / A | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] inverse of A |
| d10 | [$a29] $a97 $a51 $a31 $A | Math.sin(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] sine of A |
| d11 | [$a29] $a98 $a97 $a51 $a31 $A | Math.cos(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cosine of A |
| d12 | [$a29] $a99 $a100 $a31 $A | Math.tan(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] tangent of A |
| d13 | [$a29] $a76 $a101 $a31 $A | 1 / Math.cos(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] secant of A |
| d14 | [$a29] $a98 $a76 $a101 $a31 $A| 1 / Math.sin(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cosecant of A |
| d15 | [$a29] $a98 $a99 $a100 $a31 $A| 1 / Math.tan(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] cotangent of A |
| d16 | [$a29] $a102 $a103 $a22 $a31 $A| Math.log(A) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] natural log of A |
| d17 | $A $a33 [$a29] $a102 $a103 $a22 $a31 $B | Math.pow(A, Math.log(B)) | 0 | 1 | 0 | 1 | 0 | 1 | 0 | 1 | $a31 (of) | A to [the] natural log of B |
| d18 | [$a29] $a22 $a31 $A $a95 $B | Math.log(A)/Math.log(B) | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 | $a31 (of), $a95 (base) | [The] log of A base B |
| d19 | $A $a33 [$a29] $a22 $a31 $B $a95 $C | Math.pow(A, log_c(B)) | 0 | 1 | 0 | 1 | 0 | 1 | 0 | 1 | $a31, $a95 | A to [the] log of B base C |
| d20 | [$a29] $cNum $a22 [$a23] $a31 $A | Math.log(A) / Math.log(C) | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $cNum, $a31 (of) | [The] Nth logarithm of A |
| d21 | $A $a33 [$a29] $cNum $a93 $a94 | Math.pow(A, C) | 0 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | None | A to [the] Nth power |
| d22 | $A $a50 $a37 | Math.pow(A, 2) | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A squared |
| d23 | $A $a52 $a37 | Math.pow(A, 3) | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A cubed |
| d25 | $A [$P_Action/$P_Passiv] [$a29] $N_Add $B | A + B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Add | A [using/under] [the] addition to/with/of B |
| d26 | $A [$P_Action/$P_Passiv] [$a29] $N_Sub_Norm $B | A - B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Sub_Norm | A [using/under] [the] subtraction of/with/by B |
| d27 | $A [$P_Action/$P_Passiv] [$a29] $N_Sub_Flip $B | B - A | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Sub_Flip | A [using/under] [the] subtraction from B |
| d28 | $A [$P_Action/$P_Passiv] [$a29] $N_Mul $B| A * B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Mul | A [using/under] [the] multiplication of/by/with B |
| d29 | $A [$P_Action/$P_Passiv] [$a29] $N_Div $B| A / B | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 1 | $P_Action, $P_Passiv, $N_Div | A [using/under] [the] division of/by/with/from B |
| d40 | [$a29] $a55 $a31 $A | Math.pow(A, 0.5) OR A/2 | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 1 | $a31 (of) | [The] Half of A |
| d41 | $A $a56 $a37 | A / 2 | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A halved |
| d42 | $A [$P_Passiv] $a56 $a36 | A / 2 | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 0 | $P_Passiv | A [undergoing] halving |
| d43 | $a89 $a90 $A | A * 2 | 0 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | None | Double A |
| d44 | $A $a89 $a90 $a59 | A * 2 | 0 | 0 | 0 | 1 | 0 | 1 | 0 | 0 | None | A doubled |
| d45 | $A [$P_Passiv] $a89 $a91 | A * 2 | 1 | 0 | 0 | 0 | 1 | 0 | 0 | 0 | $P_Passiv | A [undergoing] doubling |


#### Table 4: Prepositional & Auxiliary Combinations Matrix (Lexical Grammar Variables)

| Variable Block | Expected Phrasing & Words Mapped | Mathematical Engine Purpose / JS Resolution Logic |
|----------------|----------------------------------|---------------------------------------------------|
| `$P00_Noise` | "the influence of", "a total of", "an effect of", etc. | Optional padding logic flag. Pure filler variables used by users to complete syllable counts legally. Safe to execute JS stripping logic upon match before deeper operational evaluation occurs. |
| `$P_Action` | "using", "with", "by", "using with", "with using" | Sets operator mode mapping to true `func()`. Connects previous target base logically into following functional noun mapping blocks. |
| `$P_Passiv` | "undergoing", "under", "with undergoing", "undergoing with" | Same core connective state as `$P_Action`, but flags structural linguistic flow passively. Tells JS that user noun target is having an operation placed *upon* them logically. |
| `$N_Add` | "addition", "addition to", "addition with", "addition of" | Strict Lexical mapped operational execution combinations terminating into basic Math (A + B). Resolves logic mapped from table $a43, $a44, $a45 ("add-i-tion"). |
| `$N_Sub_Norm` | "subtraction", "subtraction with", "subtraction of", "subtraction by" | Noun combination base. Forward Math Execution mapping (A - B) from substrings ($a47, $a121). |
| `$N_Sub_Flip` | "subtraction from" | Flipped operator mapping logic mapped heavily around string component "from". Math logic strictly executes inversely for inputs mapping (B - A). |
| `$N_Mul` | "multiplication", "multiplication with", "multiplication by", "multiplication of" | Combination chunking execution parameters. Base math executes straight input chain mapped logic structure (A * B). |
| `$N_Div` | "division", "division with", "division by", "division of", "division from" | Resolves any trailing grammar strings on execution map. Follows forward functional state math (A / B) natively mapping ($a118, $a119, $a120). Includes 'from' as forward function explicitly by lexical grammar structure default here rather than in `$N_Sub_Flip`. |


#### Table 5: Modifier & Ordinal Definition Matrix ($cNum Mapping Variables)

This defines every legal programmatic variable that maps natively to numerical `$cNum` constants required in fractions, roots, power modifiers, and logarithm bases throughout Table 3.

| `$cNum` Output | Standard Ordinal / Base Strings | Systematic / Latin / Greek Roots | Archaic / Obscure Terminologies | Exact Mapped Substring Target Links |
|----------------|---------------------------------|----------------------------------|---------------------------------|-------------------------------------|
| `0`  | Zeroth | N/A | N/A | `[a24,a58]`, `[a25,a26,a58]` |
| `1`  | First | N/A | N/A | `[a15,a57]` |
| `2`  | Second, Half | Quadratic, Square | N/A | `[a76,a96]`, `[a55]`, `[a67,a60,a53]`, `[a50]` |
| `3`  | Third | Cubic | N/A | `[a14]`, `[a52,a53]` |
| `4`  | Fourth | Quartic, Quadrantal, Tetragonal | Tetradic, Tessaric | `[a03,a58]`, `[a66,a53]`, `[a67,a65,a49]`, `[a62,a64]` |
| `5`  | Fifth | Quintic, Quinary, Pentagonal | Pentadic | `[a15]`, `[a70,a69,a53]`, `[a72,a64]` |
| `6`  | Sixth | Sextic, Senary, Hexagonal | Hexadic, Sextantal | `[a05,a58]`, `[a74,a75]`, `[a77,a64]` |
| `7`  | Seventh | Septic, Septenary, Heptagonal | Heptadic | `[a06,a58]`, `[a122,a75]`, `[a122,a10,a71,a21]`, `[a78,a64]` |
| `8`  | Eighth | Octic, Octonary, Octagonal | Octadic | `[a07,a58]`, `[a79,a75]`, `[a126,a64]` |
| `9`  | Ninth | Nonic, Nonary | Enneadic | `[a08,a58]`, `[a80,a53]`, `[a81,a82,a34,a83]` |
| `10` | Tenth | Decic, Denary | Decadic | `[a09,a58]`, `[a84,a53]`, `[a123,a34,a21]`, `[a84,a34,a83]` |
| `11` | Eleventh | Undecic, Undenary | Hendecadic, Hendecagonal, Undecagonal | `[a10,a58]`, `[a85,a84,a53]`, `[a85,a123,a34,a21]`, `[a86,a84,a64]` |
| `12` | Twelfth | Duodecic, Duodenary, Dodecagonal | Dodecadic, Duodecagonal | `[a11,a13]`, `[a87,a84,a53]`, `[a124,a123,a34,a21]`, `[a88,a84,a34,a83]` |


#### Table 6: Numeric Flow, Decimals, & The `$AndMatrix` Lock-In State Parser

| Logic Rule / Mode | Substring/Trigger Condition | Operational Definition within Engine | Grammatical State Lock-in |
|-------------------|-----------------------------|--------------------------------------|---------------------------|
| **Zed/Zero Equivalence** | `[a24]` OR `[a25, a26]` | Functionally identical mapping outputs for mathematical logic = 0. Distinct ONLY during syllable execution step (1 syl vs 2 syl). | N/A |
| **Oh Equivalence** | `[a24]` OR `[a25, a26]` | Functionally identical mapping outputs for mathematical logic = 0. Distinct ONLY during syllable execution step (1 syl vs 2 syl). | N/A |
| **`Parse_State_Float`** | The trigger `"point"` `[a41]` | Converts all succeeding numeric outputs to floating decimal operations. Invalidates "Hundreds/Thousands" variables. | Trailing entries MUST be singular $BaseNums (`zero, zed, one, five, etc.`). Fails grammar check if trailing string parses ordinal nouns (e.g., `point ten` correctly executes mechanically as `point one zero` mapping internally, `point twenty` is fatal error). |
| **`$And_Hundreds`** | `$BaseNum + "hundred and" + $BaseNum` | "One hundred and two". Triggers Boolean lock on Hundreds formatting string globally for the user's thread. | `IF $And_Hundreds == 1`, "One hundred two" is fatal error. |
| **`$And_Thousands`** | `$BaseNum + "thousand and" + $BaseNum` | "Two thousand and ten". Tracks specific positional AND mapping array index for `AndMatrix`. | Inherits strict execution format block. Users must maintain identical 'and' usage in respective n-relative boundaries. |


---

### Part 3: Countku Engine Implementation Guide

**Developer Implementation Paradigm:**
To implement the Countku parsing engine flawlessly within JS/HTML state execution, the string parser MUST process user input via this rigid chronological sequence:

1. **Syllable & Haiku Constraint Check:** 
   Validate raw user string. The engine must check against the 5-7-5 syllable rhythm utilizing strict English logic (referencing silent 'e' drop-outs mapped within Table 1). An execution string is mathematically FATAL and must reject if a word fragment / single syllable substring is cut in half by a line break (e.g. Ku line ends in "ze-" and following line starts with "ro").
2. **Grammatical Noise Stripping:** 
   Cross-reference user input against Table 4 `$P00_Noise`. Target these exact BS phrases ("the influence of", "a total of", "an effect of") and `replace.('')` them globally from the processing execution logic to expose raw mathematical anchors. 
3. **Lexical Tokenization:** 
   Iterate Table 1 `$a00-a125` across remaining tokens to generate numerical bases, scaling variables, and structural type masks. Verify Ordinals natively against Table 5 mappings to derive execution constants (`$cNum`).
4. **State-Machine Rules ($AndMatrix & Floats):**
   Evaluate structural grammar format using Table 6. Lock positional formatting into the `$AndMatrix` string array. Immediately reject input if positional boolean bindings contradict previously locked haiku-strings (e.g. failing the 'One hundred two' vs 'One hundred and two' parameter limit). Evaluate standard numbers vs sequence digits natively based on current trigger position from `"point"` logic state execution flag.
5. **AST Operator Generation:**
   Execute mapping across Table 3 and 4 simultaneously. Collapse Preposition and Target Strings (`$P_Passiv`, `$N_Add`, etc.) into node configurations. Natively inverse operations upon detecting `$P_Passiv` or flipped target flags (mapping "A subtracted from B" natively to B - A parameters before mathematical processing). 
6. **Execution Target Check:** 
   Evaluate generated AST JavaScript natively against absolute Math library operators (`Math.sin`, `Math.pow`, `Math.cbrt`). Validate the generated output float rigorously checks precisely `== n+1` to iterate counting bot successfully.
   
---

# Changelog

## v5.0.0 (2026-05-17)
### Major Rewrite — Database-driven engine
- **Exponentiation unified to `**` operator**: All power/root operations now use `**` instead of mixed `Math.pow()` and `**`. E.g., `(5)**2`, `(8)**(1/3)`.
- **Expression wrapping for `to` power**: `[expression] to the [ordinal]` now wraps the entire preceding expression. E.g., `four minus three to the power of two` → `(4-3)**2 = 1`.
- **`of` as root trigger**: `[ordinal] of [argument]` produces root. E.g., `a fiftieth of five` → `(5)**(1/50)`.
- **Multi-word ordinal composition**: `sixty eighth` composes to 68. E.g., `sixty eighth root of ten` → `(10)**(1/68)`.
- **All -tieth ordinals added**: twentieth, thirtieth, fortieth, fiftieth, sixtieth, seventieth, eightieth, ninetieth, hundredth, thousandth, millionth, billionth.
- **Function auto-close on operators**: When an operator appears inside a function argument, the function paren auto-closes. E.g., `sine of zero minus three` → `Math.sin(0)-3` (not `Math.sin(0-3)`).
- **Added words**: beside, executing, for, decillion, having, accounted, it, multiplied, logarithm.
- **Table 1 bit flags now drive parser**: IsBase, IsScale, IsPrep, IsPassiv, Pre_A, Pre_The, Pro_Of used as grammar rules.
- **Database file established at `/database/current.txt`**.

## v4.0.0 (2026-05-17)
### Ordinal roots/powers, help screen, debug console
- Systematic/latin ordinals: quadratic, cubic, quartic, quintic, sextic, septic, octic, nonic, decic, undecic, duodecic, tessaric, quadrantal.
- Generic `root` and `power` handlers after any ordinal.
- Help screen with syntax reference.
- Debug console for math preview.
- Tessaric root bug fix (multi-word number composition inside ordinals).

## v3.0.0 (2026-05-17)
### Variant tracking, composition rules, extended DB
- Variant conflict detection (zero/zed/oh, times/multiplied, e/euler's).
- Multiplier in-place composition ("four hundred" → 400).
- Added: subtraction from, half of, double, after, natural, logarithm, absolute value.
- Noise phrases: "the influence of", "a total of", "an effect of", "type shit".

## v2.0.0 (2026-05-17)
### Word-to-math engine with HTML literals approach
- HTML dictionary with data-word/data-math/data-syllables attributes.
- Dual-check: HaikuValidator + CountkuConverter.
- Fallover syllable system for 5-7-5 line detection.
- $lastW tracking ($var, $num, $func, $fluff, $prep).
- Ordinal state machine for power/root closing.

## v1.0.0 (2026-05-17)
### Initial release — 3-mode counting game
- Normal (Base 10), Hard (Base 2), WTF (Base 16).
- Haiku variant concept introduced.
- Standalone HTML page.
"""

let render() = file
