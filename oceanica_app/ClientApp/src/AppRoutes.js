import { Home } from "./components/Home";
import { default as Vessel } from "./components/Vessel";
import { default as Departament } from "./components/Departament";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/Vessel',
        element: <Vessel />
    },
    {
        path: '/Departament',
        element: <Departament />
    }
];

export default AppRoutes;