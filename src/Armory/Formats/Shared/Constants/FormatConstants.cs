using System.Collections.Immutable;
using ClosedXML.Excel;

namespace Armory.Formats.Shared.Constants
{
    public static class FormatConstants
    {
        public static readonly IImmutableList<string> WeaponsAndAmmunitionHeader = ImmutableList.Create("TIPO ARMA",
            "MARCA", "MODELO", "CALIBRE", "No. ARMA", "CANT. PROVEEDORES", "CAPACIDAD PROVEEDOR", "TIPO DE MUNICIÓN",
            "CALIBRE", "MARCA", "LOTE", "CANTIDAD DE MUNICIÓN");

        public static readonly IImmutableList<string> SpecialEquipmentsHeader =
            ImmutableList.Create("ÍTEM", "TIPO", "MODELO", "SERIE", "CANTIDAD");

        public static readonly IImmutableList<string> ExplosivesHeader =
            ImmutableList.Create("TIPO DE MUNICIÓN", "CALIBRE", "MARCA", "LOTE", "No. SERIE", "CANTIDAD");

        public static readonly IImmutableList<string> AssignedWeaponMagazineFormatItemsHeader = ImmutableList.Create(
            "ÍTEM", "GRUPO O DEPENDENCIA A VERIFICAR", "GRADO", "NOMBRE Y APELLIDOS", "TIPO DE ARMA", "No. DE ARMA",
            "CANT. PROVEEDORES", "CANT. MUNICIÓN", "LOTE MUNICION", "CARTUCHO DE LA VIDA (SI O NO)",
            "VERIFICADO EN FISICO (SI O NO)", "NOVEDAD (SI O NO)", "OBS. AL ITEM");

        public static string FormatTitle => "FUERZA AÉREA COLOMBIANA";

        public static string WarMaterialDeliveryCertificateFormatName =>
            "FORMATO ACTA DE ENTREGA DE MATERIAL DE GUERRA A CADETES, ALUMNOS Y SOLDADOS";

        public static string WarMaterialAndSpecialEquipmentAssignmentFormatName =>
            "FORMATO ASIGNACIÓN MATERIAL DE GUERRA Y EQUIPO ESPECIAL";

        public static string AssignedWeaponMagazineFormatName => "FORMATO REVISTA ARMAMENTO ASIGNADO O EN CUSTODIA";

        public static XLColor HeaderColor => XLColor.FromHtml("#FFFF99");
    }
}
