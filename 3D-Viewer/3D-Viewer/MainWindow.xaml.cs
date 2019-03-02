using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This class creates a 3D object, a camera, lighting, and adds it to a canvas
    /// Additionally, there are events for when the value of the sliders changes
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Viewport3D myViewport = new Viewport3D();
            Model3DGroup myModel3D = new Model3DGroup();
            GeometryModel3D myGeoModel = new GeometryModel3D();
            ModelVisual3D myModelVisual = new ModelVisual3D();

            //Constructs and assigns the camera for the scene
            PerspectiveCamera myCam = new PerspectiveCamera();
            myCam.Position = new Point3D(0, 0, 2);
            myCam.LookDirection = new Vector3D(0, 0, -1);
            myCam.FieldOfView = 90;
            myViewport.Camera = myCam;

            //Creates lighting for the scene
            DirectionalLight myLighting = new DirectionalLight();
            myLighting.Color = Colors.Azure;
            myLighting.Direction = new Vector3D(-.5, -.5, -.5);
            myModel3D.Children.Add(myLighting);

            MeshGeometry3D myMesh = new MeshGeometry3D();

            Vector3DCollection myNormalCollection = new Vector3DCollection();
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myNormalCollection.Add(new Vector3D(0, 0, 1));
            myMesh.Normals = myNormalCollection;

            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, -0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(-0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
            myMesh.Positions = myPositionCollection;

            PointCollection myTextureCoordinatesCollection = new PointCollection();
            myTextureCoordinatesCollection.Add(new Point(0, 0));
            myTextureCoordinatesCollection.Add(new Point(1, 0));
            myTextureCoordinatesCollection.Add(new Point(1, 1));
            myTextureCoordinatesCollection.Add(new Point(1, 1));
            myTextureCoordinatesCollection.Add(new Point(0, 1));
            myTextureCoordinatesCollection.Add(new Point(0, 0));
            myMesh.TextureCoordinates = myTextureCoordinatesCollection;

            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myMesh.TriangleIndices = myTriangleIndicesCollection;

            myGeoModel.Geometry = myMesh;

            //Constructs and assigns the material of the 3D object
            SolidColorBrush myBrush = new SolidColorBrush(Colors.RoyalBlue);
            DiffuseMaterial myMaterial = new DiffuseMaterial(myBrush);
            myGeoModel.Material = myMaterial;

            RotateTransform3D myYRotation = new RotateTransform3D();
            AxisAngleRotation3D myYAxis = new AxisAngleRotation3D();
            myYAxis.Axis = new Vector3D(0, 3, 0);
            myYAxis.Angle = YSlider.Value;
            myYRotation.Rotation = myYAxis;

            RotateTransform3D myXRotation = new RotateTransform3D();
            AxisAngleRotation3D myXAxis = new AxisAngleRotation3D();
            myXAxis.Axis = new Vector3D(3, 0, 0);
            myXAxis.Angle = XSlider.Value;
            myXRotation.Rotation = myXAxis;

            //Setting fields for the viewport itself and adding the viewport to the canvas
            myModel3D.Children.Add(myGeoModel);
            myModelVisual.Content = myModel3D;
            myViewport.Children.Add(myModelVisual);
            myViewport.Height = 200;
            myViewport.Width = 200;
            myViewport.VerticalAlignment = VerticalAlignment.Center;
            myViewport.HorizontalAlignment = HorizontalAlignment.Right;
            this.myCanvas.Children.Add(myViewport);
        }
    }
}
