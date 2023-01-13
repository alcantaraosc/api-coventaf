using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{        
    public class ARTICULOS
    {
        public ARTICULOS()
        {
            //ALIAS_PRODUCCION = new HashSet<ALIAS_PRODUCCION>();
            //ART_UND_DISTRIBUCI = new HashSet<ART_UND_DISTRIBUCI>();
            //ARTICULO_FOTO = new HashSet<ARTICULO_FOTO>();
            //ARTICULO_ENSAMBLE = new HashSet<ARTICULO_ENSAMBLE>();
            //ARTICULO_ENSAMBLE1 = new HashSet<ARTICULO_ENSAMBLE>();
            //ARTICULO_PRECIO = new HashSet<ARTICULO_PRECIO>();
            //ARTICULO_ALTERNO = new HashSet<ARTICULO_ALTERNO>();
            //ARTICULO_ALTERNO1 = new HashSet<ARTICULO_ALTERNO>();
            //ARTICULO_PROVEEDOR = new HashSet<ARTICULO_PROVEEDOR>();
            //CLASIFIC_ADI_ARTICULO = new HashSet<CLASIFIC_ADI_ARTICULO>();
            //COMISION_ARTICULO = new HashSet<COMISION_ARTICULO>();
            //COMISION_EXCEPCION = new HashSet<COMISION_EXCEPCION>();
            //COSTO_STD_DESGL = new HashSet<COSTO_STD_DESGL>();
            //DESPACHO_DETALLE = new HashSet<DESPACHO_DETALLE>();
            //DISTRIBUCION_ARTICULO = new HashSet<DISTRIBUCION_ARTICULO>();
            //DOC_POS_LINEA = new HashSet<DOC_POS_LINEA>();
            //EMBARQUE_LINEA = new HashSet<EMBARQUE_LINEA>();
            //ESCALA_BONIF = new HashSet<ESCALA_BONIF>();
            //ESCALA_BONIF1 = new HashSet<ESCALA_BONIF>();
            //ESCALA_DCTO = new HashSet<ESCALA_DCTO>();
            //EXISTENCIA_BODEGA = new HashSet<EXISTENCIA_BODEGA>();
            //FACTURA_LINEA = new HashSet<FACTURA_LINEA>();
            //CLASIFICACION_VENTA = new HashSet<CLASIFICACION_VENTA>();
            //EXCEPCION_D104 = new HashSet<EXCEPCION_D104>();
            //GARANTIAS_DOC_FA = new HashSet<GARANTIAS_DOC_FA>();
            //GARANTIAS_PED_FA = new HashSet<GARANTIAS_PED_FA>();
            //SP_PRONOSTICO_DETALLE = new HashSet<SP_PRONOSTICO_DETALLE>();
            //PRECIO_ART_PROV = new HashSet<PRECIO_ART_PROV>();
            //EXISTENCIA_CIERRE = new HashSet<EXISTENCIA_CIERRE>();
            //GLOBALES_CO = new HashSet<GLOBALES_CO>();
            //GARANTIAS_DOC_CC = new HashSet<GARANTIAS_DOC_CC>();
            //GARANTIAS_DOC_CO = new HashSet<GARANTIAS_DOC_CO>();
            //GARANTIAS_DOC_CP = new HashSet<GARANTIAS_DOC_CP>();
            //BOLETA_INV_FISICO = new HashSet<BOLETA_INV_FISICO>();
            //LIQUIDAC_GASTO = new HashSet<LIQUIDAC_GASTO>();
            //LINEA_DOC_INV = new HashSet<LINEA_DOC_INV>();
            //LOTE = new HashSet<LOTE>();
            //ORDEN_COMPRA_LINEA = new HashSet<ORDEN_COMPRA_LINEA>();
            //OT_ARTICULO = new HashSet<OT_ARTICULO>();
            //OT_REPORTE_CONSUMO = new HashSet<OT_REPORTE_CONSUMO>();
            //PEDIDO_SUGERIDO = new HashSet<PEDIDO_SUGERIDO>();
            //PEDIDO_LINEA = new HashSet<PEDIDO_LINEA>();
            //PROC_ARTICULO = new HashSet<PROC_ARTICULO>();
            //PRONOSTICO_DETALLE = new HashSet<PRONOSTICO_DETALLE>();
            //REGLA_DESCUENTO = new HashSet<REGLA_DESCUENTO>();
            //SOLICITUD_OC_LINEA = new HashSet<SOLICITUD_OC_LINEA>();
            //TRANSACCION_INV = new HashSet<TRANSACCION_INV>();
            //TRASPASO_POS_DET = new HashSet<TRASPASO_POS_DET>();
            //COSTO_UEPS_PEPS = new HashSet<COSTO_UEPS_PEPS>();
        }
        //[Key]        
        [StringLength(20)]
        public string Articulo { get; set; }

        [StringLength(4)]
        public string PLANTILLA_SERIE { get; set; }

        [Required]
        [StringLength(254)]
        public string Descripcion { get; set; }

        [StringLength(12)]
        public string CLASIFICACION_1 { get; set; }

        [StringLength(12)]
        public string CLASIFICACION_2 { get; set; }

        [StringLength(12)]
        public string CLASIFICACION_3 { get; set; }

        [StringLength(12)]
        public string CLASIFICACION_4 { get; set; }

        [StringLength(12)]
        public string CLASIFICACION_5 { get; set; }

        [StringLength(12)]
        public string CLASIFICACION_6 { get; set; }

        public decimal? FACTOR_CONVER_1 { get; set; }

        public decimal? FACTOR_CONVER_2 { get; set; }

        public decimal? FACTOR_CONVER_3 { get; set; }

        public decimal? FACTOR_CONVER_4 { get; set; }

        public decimal? FACTOR_CONVER_5 { get; set; }

        public decimal? FACTOR_CONVER_6 { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO { get; set; }

        [Required]
        [StringLength(1)]
        public string ORIGEN_CORP { get; set; }
        [Required]
        public decimal PESO_NETO { get; set; }

        public decimal PESO_BRUTO { get; set; }

        public decimal VOLUMEN { get; set; }

        public short BULTOS { get; set; }

        [Required]
        [StringLength(4)]
        public string ARTICULO_CUENTA { get; set; }

        [Required]
        [StringLength(4)]
        public string IMPUESTO { get; set; }

        public decimal FACTOR_EMPAQUE { get; set; }

        public decimal FACTOR_VENTA { get; set; }

        public decimal EXISTENCIA_MINIMA { get; set; }

        public decimal EXISTENCIA_MAXIMA { get; set; }

        public decimal PUNTO_DE_REORDEN { get; set; }

        [Required]
        [StringLength(1)]
        public string COSTO_FISCAL { get; set; }

        [Required]
        [StringLength(1)]
        public string COSTO_COMPARATIVO { get; set; }
        [Required]
        public decimal COSTO_PROM_LOC { get; set; }
        [Required]
        public decimal COSTO_PROM_DOL { get; set; }
        [Required]
        public decimal COSTO_STD_LOC { get; set; }
        [Required]
        public decimal COSTO_STD_DOL { get; set; }
        [Required]
        public decimal COSTO_ULT_LOC { get; set; }
        [Required]
        public decimal COSTO_ULT_DOL { get; set; }
        [Required]
        public decimal PRECIO_BASE_LOCAL { get; set; }
        [Required]
        public decimal PRECIO_BASE_DOLAR { get; set; }
        [Required]
        public DateTime ULTIMA_SALIDA { get; set; }
        [Required]
        public DateTime ULTIMO_MOVIMIENTO { get; set; }
        [Required]
        public DateTime ULTIMO_INGRESO { get; set; }
        [Required]
        public DateTime ULTIMO_INVENTARIO { get; set; }

        [Required]
        [StringLength(1)]
        public string CLASE_ABC { get; set; }
        [Required]
        public short FRECUENCIA_CONTEO { get; set; }

       
        [StringLength(20)]
        public string CODIGO_BARRAS_VENT { get; set; }

        [StringLength(20)]
        public string CODIGO_BARRAS_INVT { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTIVO { get; set; }

        [Required]
        [StringLength(1)]
        public string USA_LOTES { get; set; }

        [Required]
        [StringLength(1)]
        public string OBLIGA_CUARENTENA { get; set; }
        [Required]
        public short MIN_VIDA_COMPRA { get; set; }
        [Required]
        public short MIN_VIDA_CONSUMO { get; set; }
        [Required]
        public short MIN_VIDA_VENTA { get; set; }
        [Required]
        public short VIDA_UTIL_PROM { get; set; }
        [Required]
        public short DIAS_CUARENTENA { get; set; }
        
        [StringLength(20)]
        public string PROVEEDOR { get; set; }

        [StringLength(30)]
        public string ARTICULO_DEL_PROV { get; set; }
        [Required]
        public decimal ORDEN_MINIMA { get; set; }
        [Required]
        public short PLAZO_REABAST { get; set; }
        [Required]
        public decimal LOTE_MULTIPLO { get; set; }
      
        [Column(TypeName = "text")]
        public string NOTAS { get; set; }

        [Required]
        [StringLength(1)]
        public string UTILIZADO_MANUFACT { get; set; }
        /*AQUI*/
        [StringLength(25)]
        public string USUARIO_CREACION { get; set; }

        public DateTime? FCH_HORA_CREACION { get; set; }

        [StringLength(25)]
        public string USUARIO_ULT_MODIF { get; set; }

        public DateTime? FCH_HORA_ULT_MODIF { get; set; }

        [Required]
        [StringLength(1)]
        public string USA_NUMEROS_SERIE { get; set; }

        [StringLength(1)]
        public string MODALIDAD_INV_FIS { get; set; }

        [StringLength(1)]
        public string TIPO_COD_BARRA_DET { get; set; }

        [StringLength(1)]
        public string TIPO_COD_BARRA_ALM { get; set; }

        [StringLength(1)]
        public string USA_REGLAS_LOCALES { get; set; }

        [Required]
        [StringLength(6)]
        public string UNIDAD_ALMACEN { get; set; }

        [Required]
        [StringLength(6)]
        public string UNIDAD_EMPAQUE { get; set; }

        [Required]
        [StringLength(6)]
        public string UNIDAD_VENTA { get; set; }

        [Required]
        [StringLength(1)]
        public string PERECEDERO { get; set; }

        [StringLength(13)]
        public string GTIN { get; set; }

        [StringLength(35)]
        public string MANUFACTURADOR { get; set; }

        [StringLength(4)]
        public string CODIGO_RETENCION { get; set; }

        [StringLength(4)]
        public string RETENCION_VENTA { get; set; }

        [StringLength(4)]
        public string RETENCION_COMPRA { get; set; }

        [StringLength(4)]
        public string MODELO_RETENCION { get; set; }

        [StringLength(5)]
        public string ESTILO { get; set; }

        [StringLength(5)]
        public string TALLA { get; set; }

        [StringLength(5)]
        public string COLOR { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO_COSTO { get; set; }

        [StringLength(20)]
        public string ARTICULO_ENVASE { get; set; }

        [Required]
        [StringLength(1)]
        public string ES_ENVASE { get; set; }

        [Required]
        [StringLength(1)]
        public string USA_CONTROL_ENVASE { get; set; }

        public decimal COSTO_PROM_COMPARATIVO_LOC { get; set; }

        public decimal COSTO_PROM_COMPARATIVO_DOLAR { get; set; }

        public decimal COSTO_PROM_ULTIMO_LOC { get; set; }

        public decimal COSTO_PROM_ULTIMO_DOL { get; set; }

        [Required]
        [StringLength(1)]
        public string UTILIZADO_EN_CONTRATOS { get; set; }

        [Required]
        [StringLength(1)]
        public string VALIDA_CANT_FASE_PY { get; set; }

        [Required]
        [StringLength(1)]
        public string OBLIGA_INCLUIR_FASE_PY { get; set; }

        [Required]
        [StringLength(1)]
        public string ES_IMPUESTO { get; set; }

        public byte NoteExistsFlag { get; set; }

        public DateTime RecordDate { get; set; }

        public Guid RowPointer { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(40)]
        public string U_COD_ANTIGUO { get; set; }

        [StringLength(2)]
        public string TIPO_DOC_IVA { get; set; }

        [StringLength(20)]
        public string NIT { get; set; }

        [Required]
        [StringLength(1)]
        public string CANASTA_BASICA { get; set; }

        [Required]
        [StringLength(1)]
        public string ES_OTRO_CARGO { get; set; }

        [Required]
        [StringLength(1)]
        public string SERVICIO_MEDICO { get; set; }

        [StringLength(4)]
        public string item_hacienda { get; set; }

        [StringLength(50)]
        public string CODIGO_HACIENDA { get; set; }

        [StringLength(4)]
        public string ITEM_HACIENDA_COMPRA { get; set; }

        [Required]
        [StringLength(50)]
        public string TIENDA { get; set; }

        [StringLength(4)]
        public string TIPO_EXISTENCIA { get; set; }

        [StringLength(4)]
        public string CATALOGO_EXISTENCIA { get; set; }

        [StringLength(4)]
        public string TIPO_DETRACCION_VENTA { get; set; }

        [StringLength(4)]
        public string CODIGO_DETRACCION_VENTA { get; set; }

        [StringLength(4)]
        public string TIPO_DETRACCION_COMPRA { get; set; }

        [StringLength(4)]
        public string CODIGO_DETRACCION_COMPRA { get; set; }

        [Required]
        [StringLength(1)]
        public string CALC_PERCEP { get; set; }

        public decimal? PORC_PERCEP { get; set; }

        [StringLength(4)]
        public string U_MONEDA_VENTA_BEEPOS { get; set; }

        [StringLength(20)]
        public string U_BARRA_VENTA_BEEPOS { get; set; }

        [StringLength(40)]
        public string U_COD_ANTIGUO_SUPER { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ALIAS_PRODUCCION> ALIAS_PRODUCCION { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ART_UND_DISTRIBUCI> ART_UND_DISTRIBUCI { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_FOTO> ARTICULO_FOTO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_ENSAMBLE> ARTICULO_ENSAMBLE { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_ENSAMBLE> ARTICULO_ENSAMBLE1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_PRECIO> ARTICULO_PRECIO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_ALTERNO> ARTICULO_ALTERNO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_ALTERNO> ARTICULO_ALTERNO1 { get; set; }

        //public virtual CLASIFICACION CLASIFICACION { get; set; }

        //public virtual CLASIFICACION CLASIFICACION1 { get; set; }

        //public virtual CLASIFICACION CLASIFICACION2 { get; set; }

        //public virtual CLASIFICACION CLASIFICACION3 { get; set; }

        //public virtual CLASIFICACION CLASIFICACION4 { get; set; }

        //public virtual CLASIFICACION CLASIFICACION5 { get; set; }

        //public virtual ARTICULO_COMPRA ARTICULO_COMPRA { get; set; }

        //public virtual RETENCIONES RETENCIONES { get; set; }

        //public virtual ARTICULO_COLOR ARTICULO_COLOR { get; set; }

        //public virtual ARTICULO_CUENTA ARTICULO_CUENTA1 { get; set; }

        //public virtual ARTICULO_ESTILO ARTICULO_ESTILO { get; set; }

        //public virtual IMPUESTO IMPUESTO1 { get; set; }

        //public virtual PROVEEDOR PROVEEDOR1 { get; set; }

        //public virtual MODELO_RETENCION MODELO_RETENCION1 { get; set; }

        //public virtual SERIE_PLANTILLA SERIE_PLANTILLA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_PROVEEDOR> ARTICULO_PROVEEDOR { get; set; }

        //public virtual ARTICULO_TALLA ARTICULO_TALLA { get; set; }

        //public virtual UNIDAD_DE_MEDIDA UNIDAD_DE_MEDIDA { get; set; }

        //public virtual UNIDAD_DE_MEDIDA UNIDAD_DE_MEDIDA1 { get; set; }

        //public virtual UNIDAD_DE_MEDIDA UNIDAD_DE_MEDIDA2 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CLASIFIC_ADI_ARTICULO> CLASIFIC_ADI_ARTICULO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<COMISION_ARTICULO> COMISION_ARTICULO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<COMISION_EXCEPCION> COMISION_EXCEPCION { get; set; }

        //public virtual COST_STD_BATCH COST_STD_BATCH { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<COSTO_STD_DESGL> COSTO_STD_DESGL { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DESPACHO_DETALLE> DESPACHO_DETALLE { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DISTRIBUCION_ARTICULO> DISTRIBUCION_ARTICULO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DOC_POS_LINEA> DOC_POS_LINEA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EMBARQUE_LINEA> EMBARQUE_LINEA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ESCALA_BONIF> ESCALA_BONIF { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ESCALA_BONIF> ESCALA_BONIF1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ESCALA_DCTO> ESCALA_DCTO { get; set; }
        
        //public virtual ICollection<EXISTENCIA_BODEGA> EXISTENCIA_BODEGA { get; set; }     
        //public virtual ICollection<FACTURA_LINEA> FACTURA_LINEA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CLASIFICACION_VENTA> CLASIFICACION_VENTA { get; set; }

        //public virtual NIT NIT1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EXCEPCION_D104> EXCEPCION_D104 { get; set; }

        //public virtual CATALOGO_EXISTENCIA CATALOGO_EXISTENCIA1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GARANTIAS_DOC_FA> GARANTIAS_DOC_FA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GARANTIAS_PED_FA> GARANTIAS_PED_FA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SP_PRONOSTICO_DETALLE> SP_PRONOSTICO_DETALLE { get; set; }

        //public virtual ITEMS_HACIENDA ITEMS_HACIENDA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PRECIO_ART_PROV> PRECIO_ART_PROV { get; set; }

        //public virtual TIPO_EXISTENCIA TIPO_EXISTENCIA1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EXISTENCIA_CIERRE> EXISTENCIA_CIERRE { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GLOBALES_CO> GLOBALES_CO { get; set; }

        //public virtual TIPOS_DETRACCIONES TIPOS_DETRACCIONES { get; set; }

        //public virtual TIPOS_DETRACCIONES TIPOS_DETRACCIONES1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GARANTIAS_DOC_CC> GARANTIAS_DOC_CC { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GARANTIAS_DOC_CO> GARANTIAS_DOC_CO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GARANTIAS_DOC_CP> GARANTIAS_DOC_CP { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BOLETA_INV_FISICO> BOLETA_INV_FISICO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<LIQUIDAC_GASTO> LIQUIDAC_GASTO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<LINEA_DOC_INV> LINEA_DOC_INV { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<LOTE> LOTE { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ORDEN_COMPRA_LINEA> ORDEN_COMPRA_LINEA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<OT_ARTICULO> OT_ARTICULO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<OT_REPORTE_CONSUMO> OT_REPORTE_CONSUMO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PEDIDO_SUGERIDO> PEDIDO_SUGERIDO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PEDIDO_LINEA> PEDIDO_LINEA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PROC_ARTICULO> PROC_ARTICULO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PRONOSTICO_DETALLE> PRONOSTICO_DETALLE { get; set; }

        //public virtual RETENCIONES RETENCIONES1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<REGLA_DESCUENTO> REGLA_DESCUENTO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SOLICITUD_OC_LINEA> SOLICITUD_OC_LINEA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TRANSACCION_INV> TRANSACCION_INV { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TRASPASO_POS_DET> TRASPASO_POS_DET { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<COSTO_UEPS_PEPS> COSTO_UEPS_PEPS { get; set; }
    }
}

