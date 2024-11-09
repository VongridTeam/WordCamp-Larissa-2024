
<?php
/*
Template Name: Unity WebGL Game
*/
get_header(); // Include WordPress header
?>

<div id="unity-container" style="width: 100%; height: 100%; position: absolute;">
    <canvas id="unity-canvas" style="width: 100%; height: 100%;"></canvas>
    <div id="unity-loading-bar" style="display: none;">
        <div id="unity-progress-bar-empty"></div>
        <div id="unity-progress-bar-full"></div>
    </div>
    <div id="unity-mobile-warning" style="display: none;"></div>
</div>

<script type="text/javascript">
var buildUrl = "<?php echo get_template_directory_uri(); ?>/unity-game/Build";
var loaderUrl = buildUrl + "/unity-game.loader.js";  
var config = {
    dataUrl: buildUrl + "/unity-game.data",           
    frameworkUrl: buildUrl + "/unity-game.framework.js", 
    codeUrl: buildUrl + "/unity-game.wasm",          
    streamingAssetsUrl: "StreamingAssets",
    companyName: "DefaultCompany",
    productName: "<?php the_title(); ?>",
    productVersion: "1.0",

};
    var container = document.querySelector("#unity-container");
    var canvas = document.querySelector("#unity-canvas");

    var script = document.createElement("script");
    script.src = loaderUrl;
    script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
           
        }).then((unityInstance) => {
            
        }).catch((message) => {
            alert(message);
        });
    };
    document.body.appendChild(script);
</script>

  

<?php get_footer(); // Include WordPress footer ?>
