# Unity-AutoLayout
**Unity-AutoLayout**

>![AutoLayout](https://github.com/ChallengerCY/Unity-AutoLayout/blob/master/Unity-AutoLayout/Picture%26Gif/UnityAutoLayout.gif)

>黄色绿色代表布局元素使用了Flexible控制元素的大小。
>
>红色代表布局元素使用了Preferred控制元素的大小
>
>蓝色代表布局元素使用了Minimum控制元素的大小。

**Auto Layout**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rect Transform layout 系统非常灵活，可以处理许多不同类型的布局，它还允许以完全自由的方式放置元素。然而，一些时候需要一些结构化的布局。
>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Auto layout System提供了horizontal groups, vertical groups, grids等内嵌布局方式。它允许元素根据布局组包含的内容自动控制本身的大小。例如，可以动态调整Button的大小，使其完全适应其文本内容和一些填充。
>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;auto layout system建立在Rect Transform layout system基础之上，可以用于部分或者全部的元素


**Understanding Layout Elements**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;自动布局系统是基于布局元素和布局控制器。布局元素是一个必须带有 Rect Transform的组件和其他随意组件的元素。布局元素准确的知道他自己的大小。布局元素不会直接设置它们的大小，但是通过布局控制器提供的属性可以计算它们的大小。

>![LayoutElementInspector](https://github.com/ChallengerCY/Unity-AutoLayout/blob/master/Unity-AutoLayout/Picture%26Gif/UI_LayoutElementInspector.png)

>布局元素有定义他们自己的属性:
>
- Minimum width
- Minimum height
- Preferred width
- Preferred height
- Flexible width
- Flexible height

>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;布局元素控制器使用Content Size Fitter 和Layout elements提供的布局元素信息。布局组中布局元素大小的基本原则如下:
>
1. First minimum sizes are allocated.首先分配最小大小
1. If there is sufficient available space, preferred sizes are allocated.如果有足够的可用空间，则分配首选大小。
1. If there is additional available space, flexible size is allocated.如果有额外的可用空间，则分配灵活的大小。


>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;任何带有Rect TranSform的对象都可以作为布局元素。默认情况下，他们的minimum, preferred, and flexible sizes都为0。添加一些组件则会修改这些数值。
Image和Text组件是提供布局元素属性的两个例子组件。他们可以改变preferred width 和height去匹配sprite或者文本内容。

**Layout Element Component**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如果你想重写minimum, preferred, or flexible的大小。你需要给Gameobject添加Layout Element组件。
Layout Element组件可以让你重写一个或多个布局属性的值。勾选你需要修改的属性就个可以去修改它的值。


**Understanding Layout Controllers**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Layout controllers是一个用于控制一个或多个布局元素大小和可能位置的组件，意味着组件必须带有Rect Transform组件。一个layout controller可以控制它本身的布局元素，也可以控制它的子布局元素。当然作为layout controller的同时也可以作为 layout element。

**Content Size Fitter**

>![Content Size Fitter](https://github.com/ChallengerCY/Unity-AutoLayout/blob/master/Unity-AutoLayout/Picture%26Gif/UI_ContentSizeFitterInspector.png)
>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content Size Fitter功能是作为一个layout controller，他控制自己布局元素的大小。自动布局最简单的例子是向Text组件添加Content Size Fitter。
如果将Horizontal Fit 或者 Vertical Fit设置成Preferred。Rect Transform将会调整他的宽或者高去适应文本内容。


**Aspect Ratio Fitter**

>![Aspect Ratio Fitter](https://github.com/ChallengerCY/Unity-AutoLayout/blob/master/Unity-AutoLayout/Picture%26Gif/UI_AspectRatioFitterInspector.png)
>
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Aspect Ratio Fitter通过比例控制布局元素的大小。他可以调整高度适应宽度，反之亦然。或者可以使元素适配它的父物体或包含它的父物体。Aspect Ratio Fitter 不考虑布局信息例如minimum size 和 preferred size。

**Layout Groups**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layout group作为一个控制器的功能是控制子布局元素的大小和位置。举个例子， Horizontal Layout Group会把子元素按水平方向在一起放，Grid Layout Group将子元素放到网格中。
Layout Groups不会控制它自己的大小。相反，它本身就是一个布局元素，可以由其他layout controllers控制或手动设置大小。
不管怎样分配layout group 的大小，它会根据子元素的minimum, preferred, 还有 flexible sizes属性提供的数值为其分配适当的空间。Layout groups也可以任意的嵌套。

**Driven Rect Transform properties**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Auto layout system可以控制UI元素的大小和摆放的位置，所以不应该再去场景中或者Inspector去调整这些数值。改变一些属性值则 layout controller会在下一次计算中重置布局位置。

>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RectTransform有一个driven properties概念来解决布局方面的问题。例如，一个带有Content Size Fitter的组件。将它的 Horizontal Fit 属性修改为 Minimum 或者 Preferred会驱动携带该组件的物体的RectTranform上的width做出相同的变化。此时的width属性为只读。在RectTransform上方会有一个小的信息框得知哪些属性被 Conten Size Fitter控制。

>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;除了防止手动编辑，驱动Rect Transforms properties还有其他的原因。布局可以通过改变游戏视图的大小对应的进行改变。这会导致布局元素的大小和位置发生改变，但是这样又会导致场景变成为未保存状态。但是只是通过改变游戏视图大小而将场景变成未保存状态是不合理的，所以驱动的属性值不会被记录下来，他们的改变不会导致场景发生改变。

**Technical Details**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;自动布局系统内置了某些组件，但也可以创建新的组件，以自定义方式控制布局。通过实现 auto layout system特定的接口可以实现自定义布局。

**Layout Interfaces**

- 如果组件实现接口ILayoutElement，则自动布局系统将其视为布局元素。
- 如果组件实现接口ILayoutGroup，那么它将驱动子组件的RectTransform。
- 如果组件实现了接口ILayoutSelfController，那么它将驱动自己的RectTransform。

**Layout Calculations**
>1. 通过调用ILayoutElement组件CalculateLayoutInputHorizontal来计算布局元素的最小、首选、灵活宽度。这是从下至上执行的。孩子节点在父亲节点之前计算，这样父亲节点可以在自己的计算中考虑到孩子节点的信息。
2.  通过调用ILayoutController组件的SetLayoutHorizontal来计算和设置布局元素的有效宽度，这是自上而下执行的，子节点在父亲节点之后计算，因为子节点宽度的分配需要基于父亲节点可用的全部宽度。在这一步之后，布局元素的Rect Transform就有了新的宽度。
3.  通过调用ILayoutElement组件上CalculateLayoutInputVertical来计算布局元素的最小、首选、灵活高度。这是从下至上执行的。孩子节点在父亲节点之前计算，这样父亲节点可以在自己的计算中考虑到孩子节点的信息。
4.  通过调用ILayoutController组件的SetLayoutVertical 来计算和设置布局元素的有效高度，这是自上而下执行的，子节点在父亲节点之后计算，因为子节点宽度的分配需要基于父亲节点可用的全部高度。在这一步之后，布局元素的Rect Transform就有了新的高度。

>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;自动布局系统会先计算宽度，然后计算高度。因此，计算高度可能基于宽度，但是计算宽度不能基于高度。


**Triggering Layout Rebuild**
>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;当组件上的信息发生变化导致目前布局不可用时，就需要重新计算布局信息。可以通过以下来触发:
>
>LayoutRebuilder.MarkLayoutForRebuild (transform as RectTransform);

>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;重建不会立马执行，而是在当前帧的末尾。它不直接执行的原因是，这将导致布局可能在同一帧中多次被重构，这对性能是不利的。

**触发条件:**

- >In setters for properties that can change the layout
- >In these callbacks:
- >OnEnable
- >OnDisable
- >OnRectTransformDimensionsChange
- >OnValidate (only needed in the editor, not at runtime)
- >OnDidApplyAnimationProperties




