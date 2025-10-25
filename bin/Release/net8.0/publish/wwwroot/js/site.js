// --- Scene Setup ---
const canvas = document.getElementById("spaceCanvas");
const scene = new THREE.Scene();

const camera = new THREE.PerspectiveCamera(
    75,
    window.innerWidth / window.innerHeight,
    0.1,
    1000
);
camera.position.z = 300; // farther back to see stars

const renderer = new THREE.WebGLRenderer({
    canvas: canvas,
    antialias: true,
    alpha: true // allow transparency for background
});
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.setPixelRatio(window.devicePixelRatio);
renderer.setClearColor(0x000000, 1); // dark sky

// --- Starfield ---
const starCount = 4000;
const starGeometry = new THREE.BufferGeometry();
const starPositions = [];

for (let i = 0; i < starCount; i++) {
    const x = (Math.random() - 0.5) * 2000;
    const y = (Math.random() - 0.5) * 2000;
    const z = (Math.random() - 0.5) * 2000;
    starPositions.push(x, y, z);
}

starGeometry.setAttribute("position", new THREE.Float32BufferAttribute(starPositions, 3));

const starMaterial = new THREE.PointsMaterial({
    color: 0xffffff,
    size: 1.2,
    transparent: true,
    opacity: 0.9,
    sizeAttenuation: true
});

const stars = new THREE.Points(starGeometry, starMaterial);
scene.add(stars);

// --- Floating Developer Text "< />" ---
let devText;
const loader = new THREE.FontLoader();
loader.load("/fonts/helvetiker_regular.typeface.json", function (font) {
    const textGeo = new THREE.TextGeometry("< />", {
        font: font,
        size: 20,
        height: 2,
        curveSegments: 12,
        bevelEnabled: true,
        bevelThickness: 1,
        bevelSize: 1
    });
    const textMat = new THREE.MeshStandardMaterial({
        color: 0xffffff,
        emissive: 0xffffff,
        emissiveIntensity: 0.8
    });
    devText = new THREE.Mesh(textGeo, textMat);
    devText.position.set(100, 80, -200);
    scene.add(devText);
});

// --- Lights ---
const ambient = new THREE.AmbientLight(0xffffff, 1.2);
scene.add(ambient);

const pointLight = new THREE.PointLight(0xffffff, 2);
pointLight.position.set(200, 300, 400);
scene.add(pointLight);

// --- Animation Loop ---
function animate() {
    requestAnimationFrame(animate);

    stars.rotation.y += 0.0004;
    stars.rotation.x += 0.0002;

    if (devText) {
        devText.rotation.y += 0.003;
        devText.rotation.x += 0.001;
    }

    renderer.render(scene, camera);
}
animate();

// --- Handle Resize ---
window.addEventListener("resize", () => {
    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();
    renderer.setSize(window.innerWidth, window.innerHeight);
});

